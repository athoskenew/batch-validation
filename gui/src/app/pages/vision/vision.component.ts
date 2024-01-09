import { Component, OnInit } from '@angular/core';
import { QualityVision } from '../../models/QualityVision';
import { QualityVisionService } from '../../services/QualityVision/quality-vision.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-vision',
  templateUrl: './vision.component.html',
  styleUrl: './vision.component.css'
})
export class VisionComponent implements OnInit{

  vision!: QualityVision;
  id!: number;

  constructor(
    private visionService: QualityVisionService, 
    private route: ActivatedRoute, 
    private router: Router){}

    
  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.visionService.GetVision(this.id).subscribe(data =>{
      this.vision = data.data;
    });
  }

  navigateToNewVision(): void {
    this.router.navigate(['/new-vision', this.id]);
  }

  deleteVision(): void{
    this.visionService.DeleteVision(this.id).subscribe(()=>{
      window.location.reload();
    })
  }

}
