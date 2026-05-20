import {
  Container,
  CssBaseline,
  List,
  ListItem,
  ListItemText,
} from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import NavBar from "./NavBar";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]); // Hook to "remember" state

  useEffect(() => {
    axios
      .get<Activity[]>("https://localhost:5001/api/activities")
      .then((response) => setActivities(response.data));

    return () => {};
  }, []); // Hook to produce an effect with a callback function

  return (
    <>
      <CssBaseline />
      <NavBar />
      <Container maxWidth="xl" sx={{ mt: 3 }}>
        <List>
          {activities.map((activity) => (
            <ListItem key={activity.id}>
              <ListItemText>{activity.title}</ListItemText>
            </ListItem>
          ))}
        </List>
      </Container>
    </>
  );
}

export default App;
