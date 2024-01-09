import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { MaterialComponent } from './pages/material/material.component';
import { VisionComponent } from './pages/vision/vision.component';
import { NewVisionComponent } from './pages/new-vision/new-vision.component';
import { CharacteristicsComponent } from './pages/characteristics/characteristics.component';
import { NewCharacteristicComponent } from './pages/new-characteristic/new-characteristic.component';
import { BatchesComponent } from './pages/batches/batches.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'material', component: MaterialComponent},
  {path: 'vision/:id', component: VisionComponent},
  {path: 'new-vision/:id', component: NewVisionComponent},
  {path: 'characteristics/:id', component: CharacteristicsComponent},
  {path: 'new-characteristic/:id', component: NewCharacteristicComponent},
  {path: 'batches', component: BatchesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {



}
