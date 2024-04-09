import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'users',
    pathMatch: 'full'
  },
  {
    path: 'users',
    loadComponent: () => import('./users/user.component').then(m => m.UserComponent),
    data: {
      title: 'Users'
    }
  },
  {
    path: 'roles',
    loadComponent: () => import('./roles/role.component').then(m => m.RoleComponent),
    data: {
      title: 'Roles'
    }
  }
];
