import { commonService } from "../common";
import { userEndpoint } from "./endpoints";

export const getUsers = () => commonService.get(userEndpoint)