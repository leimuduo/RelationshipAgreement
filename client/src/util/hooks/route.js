import { useHistory } from 'react-router-dom';

export const useRouteHandler = () => {
  const history = useHistory();
  return (route) => () => history.push(route)
}