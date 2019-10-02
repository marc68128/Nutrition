import { Component, OnInit } from '@angular/core';
import { MealService } from '../../services/meal/meal.service';

@Component({
  selector: 'app-meal-generator',
  templateUrl: './meal-generator.component.html',
  styleUrls: ['./meal-generator.component.less']
})
export class MealGeneratorComponent implements OnInit {
  meal;
  mealParts;
  goalCalories: Number = 480;
  goalProtides: Number = 38;
  goalLipides: Number = 17;
  goalGlucides: Number = 45;
  alimentCount : Number = 4;

  totalCalories: Number;
  totalProtides: Number;
  totalLipides: Number;
  totalGlucides: Number;

  constructor(private mealService: MealService) { }

  ngOnInit() {
  }

  public generateNew() {
    this.meal = null;
  }

  public generate(){
    this.mealService
    .generateMeal(
      this.goalCalories,
      this.goalProtides,
      this.goalLipides,
      this.goalGlucides,
      this.alimentCount)
    .subscribe((data)=>{
      console.log(data);
      this.meal = data;
      this.mealParts = data["mealParts"];
      this.totalCalories = data["totalCalories"];
      this.totalProtides = data["totalProtides"];
      this.totalLipides = data["totalLipides"];
      this.totalGlucides = data["totalGlucides"];
    });
  }

}
