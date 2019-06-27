export interface IAppMenuItem {
  url: string;
  // securityLevels: ;
  // icon: ;
  title: string;
}

const menu: IAppMenuItem[] = [
  {
    url: '/',
    title: 'Главная'
  },
  {
    url: '/current',
    title: 'Текущие заказы'
  },
  {
    url: '/carsearch',
    title: 'Поиск машины'
  },
  {
    url: '/settings',
    title: 'Settings'
  }
];

export const getMenuItems = (): IAppMenuItem[] => menu;
