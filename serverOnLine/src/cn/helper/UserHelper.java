package cn.helper;

import java.io.IOException;
import java.io.InputStream;
import java.util.List;

import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;

import mapper.UserMapper;
import pojo.User;

public class UserHelper {

	private SqlSessionFactory factory;
	
	public UserHelper() throws IOException{
		String resource = "SqlMapConfig.xml";
		InputStream inputStream = Resources.getResourceAsStream(resource);
		factory = new SqlSessionFactoryBuilder().build(inputStream);
	}
	
	public void insertUser(User user) throws Exception{
		SqlSession openSession = factory.openSession();
		
//		User user = new User();
//		user.setPassword("qwertyuiop");;
//		user.setNickname("rollinjsnowball");
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		mapper.insertUser(user);
		
		openSession.commit();
	}
	
	public void deleteUser(int account) throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		mapper.deleteUserByAccount(account);
		
		openSession.commit();
	}
	
	public void deleteUserByNname(String name) throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		mapper.deleteUserByNickname(name);
		
		openSession.commit();
	}
	
	public void updateUser(User user) throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		
//		User user = new User();
//		user.setAccount(5);
//		user.setPassword("qwertyuiop1");
//		user.setNickname("rollinjsnowball1");
		
		mapper.updateUser(user);
		
		openSession.commit();
	}
	
	public List<User> findUserByAccount(int account) throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		List<User> list = mapper.findUserByAccount(account);
		for (User user : list) {
			System.out.println(user.getAccount() + user.getNickname() + user.getPassword());
		}
		openSession.close();
		return list;
	}
	
	public List<User> findUserByName(String name) throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		List<User> list = mapper.findUserByNickname(name);
		for (User user : list) {
			System.out.println(user.getAccount() + user.getNickname() + user.getPassword());
		}
		openSession.close();
		return list;
	}
}
