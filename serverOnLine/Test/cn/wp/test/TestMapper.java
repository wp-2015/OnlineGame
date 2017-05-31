package cn.wp.test;

import java.io.InputStream;
import java.util.List;

import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.junit.Before;
import org.junit.Test;

import mapper.UserMapper;
import pojo.User;

public class TestMapper {

	private SqlSessionFactory factory;
	
	@Before
	public void setUp() throws Exception{
		String resource = "SqlMapConfig.xml";
		InputStream inputStream = Resources.getResourceAsStream(resource);
		factory = new SqlSessionFactoryBuilder().build(inputStream);
	}
	
	@Test
	public void findUser() throws Exception{
		SqlSession openSession = factory.openSession();
		//通过getMapper方法来实例化接口
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		List<User> list = mapper.findUserByNickname("c");
		System.out.println(list);
	}
	
	@Test
	public void insertUser() throws Exception{
		SqlSession openSession = factory.openSession();
		
		User user = new User();
		user.setPassword("qwertyuiop");;
		user.setNickname("rollinjsnowball");
		
		System.out.println(user.getAccount());
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		mapper.insertUser(user);
		System.out.println(user.getAccount());
		
		openSession.commit();
	}
	
	@Test
	public void deleteUser() throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		mapper.deleteUserByAccount(3);
		
		openSession.commit();
	}
	
	@Test
	public void deleteUserByNname() throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		mapper.deleteUserByNickname("r");
		
		openSession.commit();
	}
	
	@Test
	public void updateUser() throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		
		User user = new User();
		user.setAccount(5);
		user.setPassword("qwertyuiop1");
		user.setNickname("rollinjsnowball1");
		
		mapper.updateUser(user);
		
		openSession.commit();
	}
	
	@Test
	public void findUser1() throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		List<User> list = mapper.findUserByAccount(5);
		for (User user : list) {
			System.out.println(user.getAccount() + user.getNickname() + user.getPassword());
		}
		openSession.close();
	}
	
	@Test
	public void findUser2() throws Exception{
		SqlSession openSession = factory.openSession();
		
		UserMapper mapper = openSession.getMapper(UserMapper.class);
		List<User> list = mapper.findUserByNickname("r");
		for (User user : list) {
			System.out.println(user.getAccount() + user.getNickname() + user.getPassword());
		}
		openSession.close();
	}
}
