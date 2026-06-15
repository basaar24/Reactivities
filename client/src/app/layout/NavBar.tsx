import { Group } from '@mui/icons-material'
import { AppBar, Box, Container, MenuItem, MenuList, Toolbar, Typography } from '@mui/material'
import MenuItemLink from '../shared/components/MenuItemLink'
import { NavLink } from 'react-router'

export default function NavBar() {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar
        position="static"
        sx={{
          backgroundImage: 'linear-gradient(135deg, #182a73 0%, #218aae 69%, #20a7ac 89%)',
        }}
      >
        <Container maxWidth="xl">
          <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
            <MenuList disablePadding>
              <MenuItem component={NavLink} to="/" sx={{ display: 'flex', gap: 2 }}>
                <Group fontSize="large" />
                <Typography variant="h4" sx={{ fontWeight: 'bold' }}>
                  Reactivities
                </Typography>
              </MenuItem>
            </MenuList>
            <MenuList disablePadding sx={{ display: 'flex' }}>
              <MenuItemLink to="/activities">Activities</MenuItemLink>
              <MenuItemLink to="/createActivity">Create Activity</MenuItemLink>
            </MenuList>
            <MenuList disablePadding>
              <MenuItem>User menu</MenuItem>
            </MenuList>
          </Toolbar>
        </Container>
      </AppBar>
    </Box>
  )
}
