import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Annotation } from 'src/app/interfaces/annotation';
import { AnnotationService } from '../../../services/annotation.service';
import { Category } from '../../../interfaces/category';
import { CategoryService } from '../../../services/category.service';
import { ViewChild } from '@angular/core';
import { Types } from '../../../interfaces/types';
import { TypesService } from '../../../services/types.service';

@Component({
  selector: 'app-annot-list',
  templateUrl: './annot-list.component.html',
  styleUrls: ['./annot-list.component.css'],
})
export class AnnotListComponent implements OnInit {
  annotationList: Annotation[] = [];
  annotationBack: Annotation[] = [];
  typesList: Types[] = [];
  categoryList: Category[] = [];
  @ViewChild('form') form: NgForm;
  editando: boolean = false;
  annotation: Annotation = {
    id: '',
    tags: '',
    order: 0,
    type: '',
    description: '',
    categoryId: '',
    categoryName: '',
    categoryDescription: '',
  };

  constructor(
    private AnnotationService: AnnotationService,
    private CategoryService: CategoryService,
    private TypesService: TypesService
  ) {}

  ngOnInit(): void {
    this.loadData('9b0800f1-af43-425b-7035-08da3e5cb310');
    this.CategoryService.getCategories().subscribe((categoryList) => {
      this.categoryList = categoryList;
    });
    this.typesList = this.TypesService.getTypes();
  }

  loadData(value: string) {
    this.annotationList = [];
    this.annotationBack = [];
    if (value.length > 5) {
      this.AnnotationService.getAnnotationsByCategory(value).subscribe(
        (list) => {
          list = this.setFilterText(list);
          this.annotationList = list;
          this.annotationBack = list;
        }
      );
    } else {
      this.AnnotationService.getAnnotations().subscribe((list) => {
        list = this.setFilterText(list);
        this.annotationList = list;
        this.annotationBack = list;
      });
    }
  }

  onSubmit(frm: NgForm) {
    this.annotation = frm.value as Annotation;
    console.log(this.annotation);
    this.annotation.description = this.annotation.description.trim();
    if (this.editando) {
      this.AnnotationService.updateAnnotation(this.annotation).subscribe(
        (response) => {
          this.annotationList = this.annotationList.filter(
            (annot) => annot.id != response.id
          );
          this.annotationList.push(response);
          this.editando = false;
          frm.reset();
          window.location.reload();
        }
      );
    } else {
      delete this.annotation.id;
      this.AnnotationService.createAnnotation(this.annotation).subscribe(
        (annotation) => {
          this.annotationList.push(annotation);
          this.editando = false;
          frm.reset();
          window.location.reload();
        }
      );
    }
  }

  editar(annotation: Annotation) {
    this.annotation = annotation;
    this.editando = true;
  }

  excluir(Id: string) {
    if (confirm('Deseja excluir a categoria?')) {
      this.AnnotationService.deleteAnnotation(Id).subscribe((annotation) => {
        this.annotationList = this.annotationList.filter(
          (annot) => annot.id != Id
        );
      });
    }
  }

  setAdd() {
    this.form.reset();
    this.annotation.categoryId = '_';
    this.annotation.type = '_';
    this.annotation.order = 1;
    this.editando = false;
  }

  filter(value: string) {
    if (value.length > 0) {
      const filterValue = value.split(' ');
      this.annotationList = this.annotationBack;

      filterValue.forEach((value: string) => {
        this.annotationList = this.annotationList.filter((annotation) => {
          return annotation.filterText
            ?.toLowerCase()
            .includes(value.toLowerCase());
        });
      });
    }
  }

  setFilterText(annotations: Annotation[]): Annotation[] {
    annotations.forEach((annotation) => {
      annotation.filterText =
        annotation.categoryName +
        annotation.type +
        annotation.tags +
        'ord' +
        annotation.order +
        annotation.description;
      annotation.filterText = annotation.filterText
        .toLowerCase()
        .replace(/\s/g, '');
    });

    return annotations;
  }
}
