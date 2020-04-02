import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'InjectionWeb';

  /**
   *
   */
  constructor(private http:HttpClient) {
    
  }
  onClick(){

    let options = {
      headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'Accept': 'application/json'
      })

  };

    this.http.get("http://localhost:5000/api/entityModel/print"
                , options);

  }
}
