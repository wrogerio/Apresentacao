import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CategoryService } from '../../../services/category.service';
import { Category } from '../../../interfaces/category';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-categ-list',
  templateUrl: './categ-list.component.html',
  styleUrls: ['./categ-list.component.css'],
})
export class CategListComponent implements OnInit {
  categoyList: Category[] = [];
  editando: boolean = false;
  category: Category = { id: '', categoryName: '', description: '' };

  constructor(private CategoryService: CategoryService) {}

  ngOnInit(): void {
    this.CategoryService.getCategories().subscribe((categories) => {
      categories.forEach((category) => {
        this.categoyList.push(category);
      });
    });
  }

  onSubmit(frm: NgForm) {
    if (this.editando) {
      this.CategoryService.updateCategory(this.category).subscribe(
        (category) => (this.editando = false)
      );
    } else {
      this.CategoryService.createCategory(frm.value).subscribe((category) => {
        this.categoyList.push(category);
      });
    }
  }

  editar(category: Category) {
    this.category = category;
    this.editando = true;
  }

  excluir(Id: string) {
    if (confirm('Deseja excluir a categoria?')) {
      this.CategoryService.deleteCategory(Id).subscribe((category) => {
        this.categoyList = this.categoyList.filter((categ) => categ.id != Id);
      });
    }
  }

  setAdd() {
    this.editando = false;
  }
}
