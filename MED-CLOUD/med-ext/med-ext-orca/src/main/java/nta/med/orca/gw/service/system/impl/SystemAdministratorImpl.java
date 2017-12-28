package nta.med.orca.gw.service.system.impl;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Component;

import nta.med.ext.support.proto.SystemModelProto;
import nta.med.ext.support.proto.SystemServiceProto;
import nta.med.ext.support.service.system.SystemRpcService;
import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;
import nta.med.orca.gw.glossary.CommonEnum;
import nta.med.orca.gw.service.system.SystemAdministrator;

/**
 * @author dainguyen
 */
@Component("systemAdministrator")
public class SystemAdministratorImpl implements SystemAdministrator {

	@Resource
	private SystemRpcService systemRpcService;

    public SystemAdministratorImpl() {

    }
    
    @Override
    public OrcaEnvInfo findOrcaInfoByGigwanCode(String gigwanCode) {
		SystemServiceProto.GetIntegratedSystemRequest.Builder request = SystemServiceProto.GetIntegratedSystemRequest.newBuilder();
		request.setSystem(SystemServiceProto.GetIntegratedSystemRequest.System.ORCA);
		request.setHospCode(gigwanCode);
		request.setCodeType(CommonEnum.ACCT_ORCA.getValue());
		request.addAllCodeName(Arrays.asList(CommonEnum.ORCA_IP.getValue(), CommonEnum.ORCA_PORT.getValue(), CommonEnum.ORCA_USER.getValue(), CommonEnum.ORCA_PWD.getValue()));
		
		SystemServiceProto.GetIntegratedSystemResponse response = systemRpcService.getEnvironments(request.build());
		
		if(response != null && response.getSystemList().size() > 0) {
			OrcaEnvInfo orcaEnv = new OrcaEnvInfo();
			
			List<SystemModelProto.IntegratedInfo> sysInfoList = response.getSystemList().get(0).getIntegratedInfoList();
			for (SystemModelProto.IntegratedInfo info : sysInfoList) {
				if(CommonEnum.ORCA_IP.getValue().equals(info.getCodeName())){
					orcaEnv.setOrcaIp(info.getValue());
				} else if(CommonEnum.ORCA_PORT.getValue().equals(info.getCodeName())){
					orcaEnv.setOrcaPort(info.getValue());
				} else if(CommonEnum.ORCA_USER.getValue().equals(info.getCodeName())){
					orcaEnv.setOrcaUser(info.getValue());
				} else if(CommonEnum.ORCA_PWD.getValue().equals(info.getCodeName())){
					orcaEnv.setOrcaPwd(info.getValue());
				}
			}
			
			return orcaEnv;
		}
		
		return null;
	}
    
    @Override
    public List<OrcaEnvInfo> getOrcaEnvInfo(){
    	List<OrcaEnvInfo> envList = new ArrayList<OrcaEnvInfo>();
    	
    	SystemServiceProto.GetIntegratedSystemRequest.Builder request = SystemServiceProto.GetIntegratedSystemRequest.newBuilder();
		request.setSystem(SystemServiceProto.GetIntegratedSystemRequest.System.ORCA);
		request.setHospCode("");
		request.setCodeType(CommonEnum.ACCT_ORCA.getValue());
		request.addAllCodeName(Arrays.asList(CommonEnum.ORCA_IP.getValue(), CommonEnum.ORCA_PORT.getValue(), CommonEnum.ORCA_USER.getValue(), CommonEnum.ORCA_PWD.getValue()));
		
		SystemServiceProto.GetIntegratedSystemResponse response = systemRpcService.getEnvironments(request.build());
		if(response != null && response.getSystemList().size() > 0) {
			for (SystemModelProto.IntegratedEnvironment env : response.getSystemList()) {
				OrcaEnvInfo orcaEnv = new OrcaEnvInfo();
				orcaEnv.setHospCode(env.getHospCode());
				
				for (SystemModelProto.IntegratedInfo info : env.getIntegratedInfoList()) {
					if(CommonEnum.ORCA_IP.getValue().equals(info.getCodeName())){
						orcaEnv.setOrcaIp(info.getValue());
					} else if(CommonEnum.ORCA_PORT.getValue().equals(info.getCodeName())){
						orcaEnv.setOrcaPort(info.getValue());
					} else if(CommonEnum.ORCA_USER.getValue().equals(info.getCodeName())){
						orcaEnv.setOrcaUser(info.getValue());
					} else if(CommonEnum.ORCA_PWD.getValue().equals(info.getCodeName())){
						orcaEnv.setOrcaPwd(info.getValue());
					}
				}
				
				envList.add(orcaEnv);
			}
		}
		
    	return envList;
    }
}