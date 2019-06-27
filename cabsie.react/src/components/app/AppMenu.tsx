import React from 'react';
import { Link } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import { IAppMenuItem } from '../../settings/menu';
import {
  List,
  ListItem,
  ListItemIcon,
  ListItemText
} from '@material-ui/core';
import InboxIcon from '@material-ui/icons/Inbox';

export interface IAppMenuProps {
  items: IAppMenuItem[];
  onItemClick: (que: any) => void;
}

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'stretch',
    marginTop: -12
  },
  item: {},
  icon: {},
  title: {}
}));

const AppMenu = (props: IAppMenuProps) => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <List>
        {props.items.map(({ title, url }) => (
          <ListItem button key={url}>
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary={title} />
          </ListItem>
        ))}
      </List>
    </div>
  );
};

export default AppMenu;
