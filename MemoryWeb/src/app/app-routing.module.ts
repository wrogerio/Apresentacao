import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnnotListComponent } from './components/annotations/annot-list/annot-list.component';
import { CategListComponent } from './components/categories/categ-list/categ-list.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', component: AnnotListComponent },
  { path: 'categories', component: CategListComponent },
  { path: 'annotations', component: AnnotListComponent },
  { path: '**', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
