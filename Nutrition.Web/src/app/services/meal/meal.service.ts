import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MealService {

  constructor(private httpClient: HttpClient) { }

  public generateMeal(goalCalories, goalProtides, goalLipides, goalGlucides, alimentCount){
    return this.httpClient.get("https://localhost:44370/meal?goalCalories=" + goalCalories +"&goalProtides=" + goalProtides +"&goalLipides=" + goalLipides +"&goalGlucides=" + goalGlucides + "&alimentCount="+ alimentCount);
  }
  
}
