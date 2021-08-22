import { authenticate } from './authenticate';
import { register } from './register';
import { getUsers } from './getUsers';
import { get } from './get';
import { update } from './update';
import { remove } from './remove';

export const userService = {
  authenticate,
  register,
  getUsers,
  get,
  update,
  remove
}