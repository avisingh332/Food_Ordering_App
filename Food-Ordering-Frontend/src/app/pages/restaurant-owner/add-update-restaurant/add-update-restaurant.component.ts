import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RestaurantCreateRequestType } from 'src/app/models/request.model';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-add-update-restaurant',
  templateUrl: './add-update-restaurant.component.html',
  styleUrls: ['./add-update-restaurant.component.css']
})
export class AddUpdateRestaurantComponent implements OnInit {
  restaurantForm: FormGroup;

  constructor(private fb: FormBuilder, private restaurantService:RestaurantService) {
    this.restaurantForm = this.fb.group({
      name: ['', Validators.required],
      location: ['', Validators.required],
      cuisine: ['', Validators.required],
      imageUrl: [''],
      menus: this.fb.array([this.createMenuGroup()]) // Initial empty menu item
    });
  }

  ngOnInit(): void {
   
  }

  get menus(): FormArray {
    return this.restaurantForm.get('menus') as FormArray;
  }

  createMenuGroup(): FormGroup {
    return this.fb.group({
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
        next:(resp)=>{
          console.log("Successfully Added new Restaurant");
        },
        error:(err)=>{
          console.log(err);
        }
      })
    }
  }
}
