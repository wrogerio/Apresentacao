import { Component, OnInit } from '@angular/core';
import { Annotation } from 'src/app/interfaces/annotation';
import { AnnotationService } from '../../services/annotation.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  annotationList: Annotation[];
  constructor(private AnnotationService: AnnotationService) {}

  ngOnInit(): void {
    this.AnnotationService.getAnnotations().subscribe((data) => {
      this.annotationList = data.slice(0, 150);
    });
  }
}
