import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'posts',
    pathMatch: 'full'
  },
  {
    path: 'post-categories',
    loadComponent: () => import('./post-categories/post-category.component').then(m => m.PostCategoryComponent),
    data: {
      title: 'Post Categories'
    }
  },
  {
    path: 'posts',
    loadComponent: () => import('./posts/post.component').then(m => m.PostComponent),
    data: {
      title: 'Posts'
    }
  },
  {
    path: 'series',
    loadComponent: () => import('./series/seri.component').then(m => m.SeriComponent),
    data: {
      title: 'Series'
    }
  }
];
