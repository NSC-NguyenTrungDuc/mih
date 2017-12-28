package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.cpls.CplCPL0104U00GrdMasterCPL0104ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0104U00GrdMasterRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0104U00GrdMasterResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL0104U00GrdMasterCPL0104Handler  extends ScreenHandler<CplsServiceProto.CPL0104U00GrdMasterRequest, CplsServiceProto.CPL0104U00GrdMasterResponse>{
	@Resource
	private Cpl0101Repository cpl0101Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL0104U00GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0104U00GrdMasterRequest request)
			throws Exception {
		 CplsServiceProto.CPL0104U00GrdMasterResponse.Builder response=CplsServiceProto.CPL0104U00GrdMasterResponse.newBuilder();
		 String offset =  "0" ;
		 if(!StringUtils.isEmpty(request.getOffset())){
			offset = request.getOffset();
		 }
		 Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		 List<CplCPL0104U00GrdMasterCPL0104ListItemInfo> listGrdMaster=cpl0101Repository.getCPL0104U00GrdMaster(getHospitalCode(vertx, sessionId), request.getHangmogCode(), 
				 request.getSpecimenCode(), request.getEmergency(), request.getGumsaName(), startNum, Integer.parseInt(offset));
		 if(listGrdMaster !=null && !listGrdMaster.isEmpty()){
			 for(CplCPL0104U00GrdMasterCPL0104ListItemInfo item : listGrdMaster){
				 CplsModelProto.CPL0104U00GrdMasterListItemInfo.Builder info= CplsModelProto.CPL0104U00GrdMasterListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addMasterList(info);
			 }
		}
		return response.build();
	}
}
