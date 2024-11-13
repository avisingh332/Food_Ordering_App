import { Component } from '@angular/core';
import { User } from 'src/app/models/generic.model';
import { ReviewCreateRequestType } from 'src/app/models/request.model';
import { AuthService } from 'src/app/services/auth.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { ReviewService } from 'src/app/services/review.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent {
  reviews: any;
  user: User | undefined;
  restaurantId: any;
  isRestaurantOwner: boolean = false;
  isCustomer: boolean = false;
  customerReviewText: string = "";
  customerStarRating: number = 0;
  constructor(private restaurantService: RestaurantService,
    private reviewService: ReviewService,
    private authService: AuthService) {
    this.reviews = this.restaurantService.restaurantDetails.reviews;
    this.restaurantId = this.restaurantService.restaurantDetails.id;
    this.authService.user$().subscribe(user => {
      this.user = user;
      this.isRestaurantOwner = this.user?.roles.includes("RestaurantOwner") || false;
      this.isCustomer = this.user?.roles.includes("Customer") || false;

      if (this.isRestaurantOwner) {
        this.addReplyBox();
      }
    });
  }

  // add boolean value to determine status of reply box
  addReplyBox() {
    this.reviews = (this.reviews as Array<any>).map(r => {
      return {
        ...r,
        isReplyBoxOpen: false,
        replyText: ""
      }
    })
  }

  toggleReplyBox(id: string) {
    let idx = (this.reviews as Array<any>).findIndex(r => r.id == id);
    if (idx != -1) {
      this.reviews[idx].isReplyBoxOpen = !this.reviews[idx].isReplyBoxOpen;
    }
  }

  handleReplySubmit(id: string) {
    let idx = (this.reviews as Array<any>).findIndex(r => r.id == id);
    if (idx != -1 && this.user && this.user.userId) {
      // console.log(this.reviews[idx].replyText);
      let reqObj: ReviewCreateRequestType = {
        reviewText: this.reviews[idx].replyText,
        rating: 1,
        restaurantId: this.restaurantId,
        parentReviewId: id,
      }

      this.reviewService.addReview(reqObj).subscribe({
        next: (resp) => {
          this.reviews[idx].isReplyBoxOpen =false;
          this.reviews[idx].childReviews = [...this.reviews[idx].childReviews, resp];
          console.log("Reviews After Adding reply",this.reviews)
          Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Review Added Successfully",
            showConfirmButton: false,
            timer: 1500,
            toast: true,
          });
        },
        error: (err) => {
          console.log(err);
        }
      })
    }
  }

  addCustomerComment() {
    if (this.user && this.user.userId) {
      let reqObj: ReviewCreateRequestType = {
        reviewText: this.customerReviewText,
        rating: this.customerStarRating,
        restaurantId: this.restaurantId,
        parentReviewId: null,
      }
      this.reviewService.addReview(reqObj).subscribe({
        next: (resp) => {
          this.customerReviewText ="",
          this.customerStarRating = 0;
          this.reviews = [...this.reviews, {
            ...resp,
            isReplyBoxOpen: false,
            replyText: ""
          }];
          Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Review Added Successfully",
            showConfirmButton: false,
            timer: 1500,
            toast: true,
          });
        }
      })
    }
  }

  setStarRating(rating: number) {
    this.customerStarRating = rating + 1;
  }
}
