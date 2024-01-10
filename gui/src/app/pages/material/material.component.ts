import { Component } from '@angular/core';
import { Material } from '../../models/Materials';
import { MaterialService } from '../../services/Material/material.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrl: './material.component.css'
})
export class MaterialComponent {

  constructor(private materialService: MaterialService, private router: Router){}

  createMaterial(material: Material){

    this.materialService.CreateMaterial(material).subscribe((data) =>{
      this.router.navigate(['/']);
      
    });
  }
}
