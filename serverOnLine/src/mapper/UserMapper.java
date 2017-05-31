package mapper;

import java.util.List;

import pojo.User;

public interface UserMapper {

	public void insertUser(User player);
	
	public void deleteUserByAccount(int account);
	public void deleteUserByNickname(String nickname);
	
	public void updateUser(User player);
	
	public List<User> findUserByAccount(int account);
	public List<User> findUserByNickname(String nickname);
}
