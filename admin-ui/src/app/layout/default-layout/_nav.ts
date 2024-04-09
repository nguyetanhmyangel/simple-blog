import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
  },
  {
    name: 'Features',
    url: '/features',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Post Categories',
        url: '/content/post-categories',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Posts',
        url: '/features/posts',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Series',
        url: '/features/series',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Royalty',
        url: '/features/royalty',
        icon: 'nav-icon-bullet'
      }
    ]
  },
  {
    name: 'Systems',
    url: '/systems',
    iconComponent: { name: 'cil-notes' },
    children: [
      {
        name: 'Roles',
        url: '/systems/roles',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Users',
        url: '/systems/users',
        icon: 'nav-icon-bullet'
      }
    ]
  },
];
