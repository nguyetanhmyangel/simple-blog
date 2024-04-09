import { Routes } from '@angular/router';
import { DefaultLayoutComponent } from './layout';

export const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () =>
      import('./views/auth/routes').then((m) => m.routes),
  },
  {
    path: '',
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },
    children: [
      {
        path: 'dashboard',
        loadChildren: () => import('./views/dashboard/routes').then((m) => m.routes)
      },
      {
        path: 'systems',
        loadChildren: () => import('./views/systems/routes').then((m) => m.routes)
      },
      {
        path: 'features',
        loadChildren: () => import('./views/features/routes').then((m) => m.routes)
      },
    ]
  },

  { path: '**', redirectTo: 'dashboard' }
];
