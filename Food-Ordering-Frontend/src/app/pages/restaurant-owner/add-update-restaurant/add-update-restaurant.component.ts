import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RestaurantCreateRequestType } from 'src/app/models/request.model';
import { RestaurantService } from 'src/app/services/restaurant.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-update-restaurant',
  templateUrl: './add-update-restaurant.component.html',
  styleUrls: ['./add-update-restaurant.component.css']
})
export class AddUpdateRestaurantComponent implements OnInit {
  restaurantForm: FormGroup;
  isUpdate: boolean = false;
  restaurantId: string | null = null;
  constructor(private fb: FormBuilder, private restaurantService: RestaurantService, private route: ActivatedRoute
    ,private router:Router
  ) {
    this.restaurantForm = this.fb.group({

      name: ['', Validators.required],
      location: ['', Validators.required],
      cuisine: ['', Validators.required],
      imageUrl: [''],
      menus: this.fb.array([this.createMenuGroup()]) // Initial empty menu item
    });
  }

  ngOnInit(): void {
    console.log("Restaurant Details", this.restaurantService.restaurantDetails);
    this.route.paramMap.subscribe((param) => {
      let id = param.get('id');
      if (id != null) {
        this.isUpdate = true;
        this.restaurantId = id;
        this.loadData(id);
      }
    })
  }

  loadData(id: string) {
    this.restaurantService.getRestaurantById(id).subscribe({
      next: (resp) => {
        this.populateForm(resp);
      },
      error: (err) => {
        console.log(err)
      }
    })
  }
  populateForm(restaurantDetails: any) {
    // Populate the form with existing details
    let details = restaurantDetails;
    this.restaurantForm.patchValue({

      name: details.name,
      location: details.location,
      cuisine: details.cuisine,
      imageUrl: details.imageUrl
    });

    // Clear current menu items and add existing ones
    this.menus.clear();
    (details.menus as Array<any>).forEach(menuItem => {
      this.menus.push(this.fb.group({
        id: [menuItem.id],
        dishName: [menuItem.dishName, Validators.required],
        price: [menuItem.price, [Validators.required, Validators.min(0)]],
        imageUrl: [menuItem.imageUrl]
      }));
    });
  }

  get menus(): FormArray {
    return this.restaurantForm.get('menus') as FormArray;
  }

  createMenuGroup(): FormGroup {
    return this.fb.group({
      id: [null],
      dishName: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      imageUrl: ['']
    });
  }

  addMenu(): void {
    this.menus.push(this.createMenuGroup());
  }

  removeMenu(index: number): void {
    this.menus.removeAt(index);
  }

  onSubmit(): void {
    if (this.restaurantForm.valid) {
      // submission logic
      let reqObj = this.restaurantForm.value as RestaurantCreateRequestType;
      this.restaurantService.addRestaurant(reqObj).subscribe({
        next: (resp) => {
          console.log("Successfully Added new Restaurant");
        },
        error: (err) => {
          console.log(err);
        }
      })
    }
  }

  onUpdate() {
    let reqObj = this.restaurantForm.value as RestaurantCreateRequestType;
    if (this.restaurantId != null) {
      this.restaurantService.updateRestaurant(this.restaurantId, reqObj).subscribe({
        next: (resp) => {
          this.router.navigate(['/restaurant-owner','home'])
          Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Restaurant Updated Successfully",
            showConfirmButton: false,
            timer: 1500, 
            toast:true,
          });
        },
        error: (err) => {
          console.log(err);
        }
      })
    }
  }
}
