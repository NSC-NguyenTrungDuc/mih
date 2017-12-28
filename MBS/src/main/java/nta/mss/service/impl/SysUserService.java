package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.List;

import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.kcck.model.KcckSysUserModel;
import nta.kcck.service.impl.KcckApiService;
import nta.mss.entity.Hospital;
import nta.mss.entity.SysRole;
import nta.mss.entity.SysUser;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.model.SysRoleModel;
import nta.mss.model.SysUserModel;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.SysRoleRepository;
import nta.mss.repository.SysUserRepository;
import nta.mss.service.ISysUserService;

/**
 * The Class DoctorService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Service
@Transactional
public class SysUserService implements ISysUserService {
	// private static Logger LOG = LogManager.getLogger(SysUserService.class);
	private Mapper mapper;
	private SysUserRepository sysUserRepository;
	private SysRoleRepository sysRoleRepository;
	private HospitalRepository hospitalRepository;
	KcckApiService kcckApiService = new KcckApiService();
	
	public SysUserService() {
	}

	/**
	 * Instantiates a new doctor service.
	 * 
	 * @param mapper
	 *            the mapper
	 * @param doctorScheduleRepository
	 *            the doctor schedule repository
	 * @param reservationRepository
	 *            the reservation repository
	 * @param doctorRepository
	 *            the doctor repository
	 * @param departmentRepository
	 *            the department repository
	 */
	@Autowired
	public SysUserService(Mapper mapper, SysUserRepository sysUserRepository, SysRoleRepository sysRoleRepository, HospitalRepository hospitalRepository) {
		this.mapper = mapper;
		this.sysUserRepository = sysUserRepository;
		this.sysRoleRepository = sysRoleRepository;
		this.hospitalRepository = hospitalRepository;
	}

	/**
	 * Gets the doctor by doctor id.
	 * 
	 * @param doctId
	 *            the doct id
	 * @return the doctor by doctor id
	 */
	public SysUserModel getSysUser(Integer sysUserId) {
		SysUser doctor = this.sysUserRepository.findOne(sysUserId);
		return doctor == null ? null : doctor.toModel(this.mapper);
	}

	/**
	 * Gets the sys user by login id.
	 *
	 * @param loginId the login id
	 * @return the sys user by login id
	 */
	public SysUserModel getSysUserByLoginId(String loginId, Integer hospitalId) {
		List<SysUser> sysUserList = this.sysUserRepository.findByLoginIdAndHospitalId(loginId, hospitalId);
		if (sysUserList.isEmpty()) {
			return null;
		}
		return sysUserList.get(0).toModel(mapper);
	}
	
	/**
	 * get all active sysuser
	 * @return list
	 */
	public List<SysUserModel> getAllSysUser(Integer hospitalId) {
		List<SysUserModel> result = new ArrayList<>();
		List<SysUser> sysUserList = this.sysUserRepository.getAllSysUser(hospitalId);
		for (SysUser sysUser : sysUserList) {
			result.add(sysUser.toModel(mapper));
		}
		return result;
	}
	
	/**
	 * get all sys role active
	 */
	public List<SysRole> getAllUserRoles() {
		return this.sysRoleRepository.getAllSysRole();
	}
	
	/**
	 * update role for user
	 * @param sysUserModel
	 * @return boolean
	 */
	public boolean updateRoleForUser(SysUserModel sysUserModel) {
		List<SysUser> sysUserList = this.sysUserRepository.findByLoginId(sysUserModel.getLoginId(), sysUserModel.getHospitalId());
		if(!sysUserList.isEmpty()) {
			SysUser sysUser = sysUserList.get(0);
			SysRole sysRole = new SysRole();
			sysRole.setRoleId(sysUserModel.getRoleId());
			sysUser.setRole(sysRole);
			this.sysUserRepository.save(sysUser);
			return true;
		}
		return false;
	}
	
	/**
	 * update password
	 * @param sysUsermodel
	 * return boolean
	 */
	public boolean updatePasswordForUser(SysUserModel sysUserModel) {
		List<SysUser> sysUserList = this.sysUserRepository.findByLoginId(sysUserModel.getLoginId(), sysUserModel.getHospitalId());
		if(!sysUserList.isEmpty()) {
			SysUser sysUser = sysUserList.get(0);
			sysUser.setLoginPass(EncryptionUtils.cryptWithMD5(sysUserModel.getLoginPass()));
			this.sysUserRepository.save(sysUser);
			return true;
		}
		return false;
	}
	
	/**
	 * delete user
	 * @param sysUserModel
	 * @return boolean
	 */
	public boolean deleteUser(SysUserModel sysUserModel) {
		List<SysUser> sysUserList = this.sysUserRepository.findByLoginId(sysUserModel.getLoginId(), sysUserModel.getHospitalId());
		if(!sysUserList.isEmpty()) {
			SysUser sysUser = sysUserList.get(0);
			sysUser.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			this.sysUserRepository.save(sysUser);
			return true;
		}
		return false;
	}
	/**
	 * 
	 * @param sysUserModel
	 * @return
	 */
	public boolean addNewUser(SysUserModel sysUserModel) throws Exception{
		List<SysUser> sysUserList = this.sysUserRepository.findByLoginId(sysUserModel.getLoginId(), sysUserModel.getHospitalId());
		if(!sysUserList.isEmpty()){
			return false;
		}
		List<SysRole> sysRoleList = this.sysRoleRepository.findByRoleId(sysUserModel.getRoleId());
		Hospital hospital = hospitalRepository.findHospital(MssContextHolder.getHospitalId(), 1);
		
		if(sysUserList.isEmpty()) {
			SysRole sysRole = sysRoleList.get(0);
			SysUser sysUser = new SysUser();
			sysUser.setLoginId(sysUserModel.getLoginId());
			sysUser.setRole(sysRole);
			sysUser.setLoginPass(EncryptionUtils.cryptWithMD5(sysUserModel.getLoginPass()));
			sysUser.setHospital(hospital);
			this.sysUserRepository.save(sysUser);
			return true;
		}
		return false;
	}
	/**
	 * Gets the sys user by email.
	 *
	 * @param email the email
	 * @return the sys user by email
	 */
	public SysUserModel getSysUserByEmail(String email, Integer hospitalId) {
		List<SysUser> sysUserList = this.sysUserRepository.findByEmailAndHospitalId(email, hospitalId);
		if (sysUserList.isEmpty()) {
			return null;
		}
		return sysUserList.get(0).toModel(mapper);
	}

	@Override
	public SysUserModel getUserFromKcck(KcckSysUserModel sysUserModel) {
		SysUserModel sysUser = new SysUserModel();
		KcckSysUserModel responseSysUser = kcckApiService.getKcckSysUserInfo(sysUserModel);
		if(responseSysUser != null) {
			sysUser.setLoginId(responseSysUser.getUser_id());
			sysUser.setLoginName(responseSysUser.getUser_name());
			sysUser.setCode(responseSysUser.getStatus());
			if(responseSysUser.getStatus().equals("00")) {
				SysRole sysRole = sysRoleRepository.findByRoleId(1).get(0);
				SysRoleModel sysRoleModel = new SysRoleModel();
				sysRoleModel.setRoleId(sysRole.getRoleId());
				sysRoleModel.setRoleName(sysRole.getRoleName());
				sysRoleModel.setUserFlg(sysRole.getUserFlg());
				sysRoleModel.setReservationFlg(sysRole.getReservationFlg());
				sysRoleModel.setScheduleFlg(sysRole.getScheduleFlg());
				sysRoleModel.setMailSendingFlg(sysRole.getMailSendingFlg());
				sysUser.setRole(sysRoleModel);
				sysUser.setLoginPass(sysUserModel.getPassword());
			}
		}
		return sysUser;
	}
}
