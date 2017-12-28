package nta.med.service.ihis.handler.system;

import nta.med.common.util.Lists;
import nta.med.common.util.type.Tuple;
import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.infrastructure.RoutingDataSource;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetIntegratedSystemRequest;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Collection;
import java.util.HashSet;
import java.util.List;
import java.util.stream.Collectors;

@Service
@Scope("prototype")
public class GetIntegratedSystemHandler extends ScreenHandler<SystemServiceProto.GetIntegratedSystemRequest, SystemServiceProto.GetIntegratedSystemResponse>{

	private static final Log LOGGER = LogFactory.getLog(GetIntegratedSystemHandler.class);

	@Resource
	private Bas0001Repository bas0001Repository;

	@Resource
	private Bas0102Repository bas0102Repository;
	
//	@Override
//	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
//			GetIntegratedSystemRequest request) throws Exception {
//
//		if (!StringUtils.isEmpty(request.getHospCode())) {
//			List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
//			if (!CollectionUtils.isEmpty(bas0001List)) {
//				setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(
//						bas0001List.get(0).getHospCode(), bas0001List.get(0).getLanguage(), "", 1, ""));
//				LOGGER.info("GetIntegratedSystemHandler preHandle has hosp code" + bas0001List.get(0).getHospCode());
//			} else {
//				LOGGER.info("GetIntegratedSystemHandler preHandle not found hosp code");
//			}
//		} else {
//			super.preHandle(vertx, clientId, sessionId, contextId, request);
//		}
//	}

	@Override
	@Transactional(readOnly = true)
	public Tuple<Boolean, Collection<String>> isShardable(GetIntegratedSystemRequest request, Vertx vertx, String clientId, String sessionId) {
		Tuple<Boolean, Collection<String>> r = new Tuple<>(false, Lists.emptyList());
		if(StringUtils.isEmpty(request.getHospCode())){
			LOGGER.info("Get integrated system user SUPER_ADMIN, hosp_code = " + getHospitalCode(vertx, sessionId));
			r.set(true,  RoutingDataSource.getRepresentativeShards());
		} else {
			List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
			if (!CollectionUtils.isEmpty(bas0001List)) {
				setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(
						bas0001List.get(0).getHospCode(), bas0001List.get(0).getLanguage(), "", 1, ""));
				LOGGER.info("GetIntegratedSystemHandler preHandle has hosp code" + bas0001List.get(0).getHospCode());
			} else {
				LOGGER.info("GetIntegratedSystemHandler preHandle not found hosp code");
			}
		}
		return r;
	}

	@Override
	public SystemServiceProto.GetIntegratedSystemResponse mergeShards(List<SystemServiceProto.GetIntegratedSystemResponse> responses) {
		SystemServiceProto.GetIntegratedSystemResponse.Builder r = SystemServiceProto.GetIntegratedSystemResponse.newBuilder();

		for(SystemServiceProto.GetIntegratedSystemResponse item : responses) {
			r.addAllSystem(item.getSystemList());
		}

		return r.build();
	}

	@Override
	@Route(global = false)
	@Transactional(readOnly = true)
	public SystemServiceProto.GetIntegratedSystemResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SystemServiceProto.GetIntegratedSystemRequest request) throws Exception {
		SystemServiceProto.GetIntegratedSystemResponse.Builder response = SystemServiceProto.GetIntegratedSystemResponse.newBuilder();
		if(StringUtils.isEmpty(request.getHospCode())){
			LOGGER.info("Get integrated system user SUPER_ADMIN, hosp_code = " + getHospitalCode(vertx, sessionId));
			List<Bas0102> bas0102List = bas0102Repository.findByCodeTypeAndCodename(request.getCodeType(), request.getCodeNameList());
			if(CollectionUtils.isEmpty(bas0102List)){
				return response.build();
			}
			
			HashSet<String> hospCodeList = new HashSet<>(bas0102List.stream().map(Bas0102::getHospCode).collect(Collectors.toList()));
			for (String hc : hospCodeList) {
				SystemModelProto.IntegratedEnvironment.Builder integratedEnv = SystemModelProto.IntegratedEnvironment.newBuilder();
				integratedEnv.setHospCode(hc);
				
				for (Bas0102 bas0102 : bas0102List) {
					if(hc.equals(bas0102.getHospCode())){
						SystemModelProto.IntegratedInfo.Builder info = SystemModelProto.IntegratedInfo.newBuilder();
						info.setCodeName(bas0102.getCode());
						info.setValue(bas0102.getCodeName());
						integratedEnv.addIntegratedInfo(info);
					}
				}
				
				response.addSystem(integratedEnv);
			}
			
		} else {
			LOGGER.info("Get integrated system, hosp_code = " + request.getHospCode());
			SystemModelProto.IntegratedEnvironment.Builder integratedEnv = SystemModelProto.IntegratedEnvironment.newBuilder();
			integratedEnv.setHospCode(request.getHospCode());
			List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeTypeAndCodename(request.getHospCode(), request.getCodeType(), request.getCodeNameList());
			if(CollectionUtils.isEmpty(bas0102List)){
				return response.build();
			}
			
			for (Bas0102 bas0102 : bas0102List) {
				SystemModelProto.IntegratedInfo.Builder info = SystemModelProto.IntegratedInfo.newBuilder();
				info.setCodeName(bas0102.getCode());
				info.setValue(bas0102.getCodeName());
				integratedEnv.addIntegratedInfo(info);
			}
			
			response.addSystem(integratedEnv);
		}
		
		return response.build();
	}
	
}
