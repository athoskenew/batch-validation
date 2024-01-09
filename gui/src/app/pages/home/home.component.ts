import { Component, OnInit } from '@angular/core';
import { MaterialService } from '../../services/Material/material.service';
import { Material } from '../../models/Materials';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  materials: Material[] = [];
  generalMaterials: Material[] = [];

  constructor(private materialService: MaterialService, private router: Router){}

  ngOnInit(): void {

    this.materialService.GetMaterials().subscribe(data =>{
      const responseData = data.data;
      this.materials = responseData;
      this.generalMaterials = responseData;
    })
    
  }

  search(event: Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.materials = this.generalMaterials.filter(material =>{
      return material.name.toLowerCase().includes(value);
    })
  }

  delete(id: number){
    this.materialService.DeleteMaterial(id).subscribe(data =>{
      window.location.reload();
    })
  }

}
