package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00cboSimsaMagamGubunresultAfterDisRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00cboSimsaMagamGubunresultAfterDisResponse;

@Service
@Scope("prototype")
public class INP3003U00cboSimsaMagamGubunresultAfterDisHandler 
extends ScreenHandler<InpsServiceProto.INP3003U00cboSimsaMagamGubunresultAfterDisRequest, InpsServiceProto.INP3003U00cboSimsaMagamGubunresultAfterDisResponse>{
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP3003U00cboSimsaMagamGubunresultAfterDisResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INP3003U00cboSimsaMagamGubunresultAfterDisRequest request) throws Exception {
		InpsServiceProto.INP3003U00cboSimsaMagamGubunresultAfterDisResponse.Builder response = InpsServiceProto.INP3003U00cboSimsaMagamGubunresultAfterDisResponse.newBuilder();
		List<ComboListItemInfo> cboSimsas = bas0102Repository.getCht0115Q01xEditGridCell10ListItem(getHospitalCode(vertx, sessionId), "SIMSA_MAGAM_GUBUN", getLanguage(vertx, sessionId));
		List<ComboListItemInfo> afterDis = bas0102Repository.getCht0115Q01xEditGridCell10ListItem(getHospitalCode(vertx, sessionId), "RESULT_AFTER_DIS", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(cboSimsas)){
			for(ComboListItemInfo item : cboSimsas){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboSimsaMagamGubun(info);
			}
		}
		if(!CollectionUtils.isEmpty(afterDis)){
			for(ComboListItemInfo item : afterDis){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addResultAfterDis(info);
			}
		}
		return response.build();
	} 

}
