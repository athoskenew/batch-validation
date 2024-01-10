import { Component, OnInit } from '@angular/core';
import { QualityVision } from '../../models/QualityVision';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { QualityVisionService } from '../../services/QualityVision/quality-vision.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-new-vision',
  templateUrl: './new-vision.component.html',
  styleUrl: './new-vision.component.css'
})
export class NewVisionComponent implements OnInit{

  id!: number;
  qualityVisionForm!: FormGroup;

  constructor(private qualityVisionService: QualityVisionService,
    private route: ActivatedRoute, 
    private router: Router){}

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.qualityVisionForm = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      minimumQuantity: new FormControl(0, [Validators.required]),
      type: new FormControl(0, [Validators.required]),
      materialModelId: new FormControl(this.id)
    })
  }

  submit(){
    const quality : QualityVision = this.qualityVisionForm.value;
    
    this.qualityVisionService.CreateVision(quality, this.id).subscribe(() =>{
      this.router.navigate([`/vision/${this.id}`]);
    });
  }

  backToVision(){
    this.router.navigate([`/vision/${this.id}`]);
  }

}
