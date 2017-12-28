package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.bass.Inp1003U00FwkGwaListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01DoubleFindClickRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class INP1001U01DoubleFindClickHandler extends ScreenHandler<InpsServiceProto.INP1001U01DoubleFindClickRequest, SystemServiceProto.ComboResponse>{
	private static final Log LOGGER = LogFactory.getLog(INP1001U01DoubleFindClickHandler.class); 
	@Resource
	private Bas0260Repository bas0260Repository;
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01DoubleFindClickRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String controlName = request.getControlName();
		if (StringUtils.isEmpty(controlName)) {
			LOGGER.info("Control Name Null !!!!!!!!");
			return response.build();
		}
		
		if ("fbxGwa".equals(controlName)) {
			List<Inp1003U00FwkGwaListItemInfo> listGwa = bas0260Repository.getInp1003U00FwkGwaListItemInfo(getHospitalCode(vertx, sessionId), request.getBuseoYmd(), request.getFind1());
			if (!CollectionUtils.isEmpty(listGwa)) {
				for (Inp1003U00FwkGwaListItemInfo item : listGwa) {
					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					info.setCode(item.getGwa());
					info.setCodeName(item.getGwaName());
					response.addComboItem(info);
				}
			}
		}
		
		if ("fbxDoctor".equals(controlName)) {
			List<ComboListItemInfo> listDoctor = bas0270Repository.findByHospCodeDoctorGwaFDate(getHospitalCode(vertx, sessionId), request.getGwa(), request.getIpwonDate());
			if (!CollectionUtils.isEmpty(listDoctor)) {
				for (ComboListItemInfo item : listDoctor) {
					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					info.setCode(item.getCode());
					info.setCodeName(item.getCodeName());
					response.addComboItem(info);
				}
			}
		}
		return response.build();
	}

}
