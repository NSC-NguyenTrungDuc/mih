package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl0104Repository;
import nta.med.data.model.ihis.cpls.CplCPL0104U00GrdDetailCPL0104ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0104U00GrdDetailRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0104U00GrdDetailResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL0104U00GrdDetailCPL0104Handler  extends ScreenHandler<CplsServiceProto.CPL0104U00GrdDetailRequest, CplsServiceProto.CPL0104U00GrdDetailResponse> {
	@Resource
	private Cpl0104Repository cpl0104Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL0104U00GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0104U00GrdDetailRequest request)
			throws Exception {
		 CplsServiceProto.CPL0104U00GrdDetailResponse.Builder response=CplsServiceProto.CPL0104U00GrdDetailResponse.newBuilder();
		 String offset = "0" ;
		 if(!StringUtils.isEmpty(request.getOffset())){
			offset = request.getOffset();
		 }
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		 List<CplCPL0104U00GrdDetailCPL0104ListItemInfo> listGrd=cpl0104Repository.getCplCPL0104U00GrdDetailCPL0104(getHospitalCode(vertx, sessionId), request.getHangmogCode(), 
				 request.getSpecimenCode(), request.getEmergency(), startNum, Integer.parseInt(offset));
		 if(listGrd !=null && !listGrd.isEmpty()){
			 for(CplCPL0104U00GrdDetailCPL0104ListItemInfo item : listGrd){
				 CplsModelProto.CPL0104U00GrdDetailListItemInfo.Builder info= CplsModelProto.CPL0104U00GrdDetailListItemInfo.newBuilder();
				 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				 response.addDetailList(info);
			 }
		 }
		 return response.build();
	}
}
