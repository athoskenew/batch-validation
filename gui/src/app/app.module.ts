import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { MaterialComponent } from './pages/material/material.component';
import { MaterialFormComponent } from './components/material-form/material-form.component';
import { VisionComponent } from './pages/vision/vision.component';
import { NewVisionComponent } from './pages/new-vision/new-vision.component';
import { CharacteristicsComponent } from './pages/characteristics/characteristics.component';
import { NewCharacteristicComponent } from './pages/new-characteristic/new-characteristic.component';
import { BatchesComponent } from './pages/batches/batches.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MaterialComponent,
    MaterialFormComponent,
    VisionComponent,
    NewVisionComponent,
    CharacteristicsComponent,
    NewCharacteristicComponent,
    BatchesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
