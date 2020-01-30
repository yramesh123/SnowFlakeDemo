import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public teacherlist: TeacherDataModel[];
  public newweather: string;
  public myTextarea: string;
  public siteURL: string;
  weatherForm: FormGroup;

  constructor(private http: HttpClient, private formBuilder: FormBuilder, @Inject('BASE_URL') baseUrl: string) {
    
  }

  ngOnInit() {
    this.weatherForm = this.formBuilder.group({
      weathername: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.weatherForm.controls; }

  onKey(event: any)
  { // without type info
   
  }

  saveweather() {
    this.myTextarea = 'Dummy';
    this.newweather = 'Save';
    alert(this.f.weathername.value);
    this.f.weathername.setValue('');
  }

  deleteweather() {

    this.f.weathername.setValue('putteacher');
    var dm = {
      'firstName': 'George',
      'lastName': 'Kongalouth',
      'subject': 'Sanskrit',
      'empId': 8
    };
    this.siteURL = 'https://localhost:44347/api/TeacherList/PutTeacher';

    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      })
    };

    this.http.post<TeacherDataModel[]>(this.siteURL, dm, httpOptions).subscribe(result => {
      console.log(result);
      this.teacherlist = result;
      console.log(this.teacherlist);
    }, error => console.error(error));
    console.log(dm);
  }

}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface TeacherDataModel {
  firstName: string;
  lastName: string;
  subject: string;
  empId: number;
}
