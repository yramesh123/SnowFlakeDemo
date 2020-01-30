import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-food-data',
  templateUrl: './food-data.component.html'
})
export class FoodDataComponent {
  public fooditems: string[];
  public newweather: string;
  public myTextarea: string;
  public siteURL: string;
  weatherForm: FormGroup;

  constructor(private http: HttpClient, private formBuilder: FormBuilder, @Inject('BASE_URL') baseUrl: string)
  {
    this.fooditems = ['Dates', 'Burger', 'Pizza', 'DoughNut', 'Biscuits'];
  }

  ngOnInit() {
   
  }
  

}

