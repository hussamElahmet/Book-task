import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { catchError, tap } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  countriesUrl = "https://localhost:44309/api/Country";
  bookUrl = "https://localhost:44309/api/Book";
  userform: FormGroup;
 resultPenalty :string;
  ngOnInit(): void {
  }

  constructor(private http: HttpClient, private _fb: FormBuilder) {
     this.userform = this._fb.group({
      BuisnessDays: "",
      TotalPrice: "",
      Currency :"",
     })
    this.resultPenalty="";
    };
     


  onSubmit(data: any) {
    console.log(data.From);
    const headers = { 'Content-Type': 'application/json' };
        const options = {
      headers: new HttpHeaders(headers),
    };
    return this.http.get(`https://localhost:44309/api/Book/${data.From}/${data.To}/${data.CountryId}`).subscribe
    (
     ress=>this.resultPenalty=ress.toString()
  )
}

}

