package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL3010U01MaxInfoListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01SearchMaxInfoRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01SearchMaxInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL3010U01SearchMaxInfoHandler extends ScreenHandler<CplsServiceProto.CPL3010U01SearchMaxInfoRequest, CplsServiceProto.CPL3010U01SearchMaxInfoResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL3010U01SearchMaxInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U01SearchMaxInfoRequest request) throws Exception  {
		CplsServiceProto.CPL3010U01SearchMaxInfoResponse.Builder response = CplsServiceProto.CPL3010U01SearchMaxInfoResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<CPL3010U01MaxInfoListItemInfo> listMax;
		if(request.getInfoGb()){
			listMax = cpl2010Repository.getCPL3010U01MaxInfoListItemInfo(hospCode,request.getFromPartJubsuDate(),request.getToPartJubsuDate(),request.getFromSeq(),request.getToSeq());
		}else{
			listMax = cpl2010Repository.getCPL3010U01MaxInfoListItemInfo2(hospCode,request.getFromSpecimenSer(),request.getToSpecimenSer());
		}
		if(!CollectionUtils.isEmpty(listMax)){
			for(CPL3010U01MaxInfoListItemInfo item : listMax){
				CplsModelProto.CPL3010U01MaxInfoListItemInfo.Builder info = CplsModelProto.CPL3010U01MaxInfoListItemInfo.newBuilder();
				 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				 response.addMaxInfoList(info);
			}
		}
		return response.build();
	}
}
