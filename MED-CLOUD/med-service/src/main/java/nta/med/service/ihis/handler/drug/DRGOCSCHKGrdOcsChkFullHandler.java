package nta.med.service.ihis.handler.drug;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.drug.DRGOCSCHKGrdOcsChkFullInfo;
import nta.med.service.ihis.proto.DrugModelProto;
import nta.med.service.ihis.proto.DrugServiceProto;
import nta.med.service.ihis.proto.DrugServiceProto.DRGOCSCHKGrdOcsChkFullRequest;
import nta.med.service.ihis.proto.DrugServiceProto.DRGOCSCHKGrdOcsChkFullResponse;

@Service
@Scope("prototype")
public class DRGOCSCHKGrdOcsChkFullHandler extends ScreenHandler<DrugServiceProto.DRGOCSCHKGrdOcsChkFullRequest, DrugServiceProto.DRGOCSCHKGrdOcsChkFullResponse>{
	private static final Log LOG = LogFactory.getLog(DRGOCSCHKGrdOcsChkFullHandler.class);
	@Resource
	private Inv0110Repository inv0110Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DRGOCSCHKGrdOcsChkFullResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRGOCSCHKGrdOcsChkFullRequest request) throws Exception {
		String offset =  "0" ;
		if(!StringUtils.isEmpty(request.getOffset())){
			offset = request.getOffset();
		}
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		String jaeryoGubun = "%";
		if(!StringUtils.isEmpty(request.getJaeryoGubun())){
			jaeryoGubun = request.getJaeryoGubun();
		}
		
		 List<DRGOCSCHKGrdOcsChkFullInfo> listGrdOcsChkFullInfos = inv0110Repository.getDRGOCSCHKGrdOcsChkFullInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJaeryoCode(), request.getJaeryoName(), request.getPreSmallCode(),
				 													request.getSmallCode(), request.getDrgPackYn(), request.getPhamarcyYn(), request.getPowderYn(), request.getHubalYn(), request.getMayakYn(), request.getStockYn(), request.getBeforeUseYn(),
				 													request.getWonnaeDrgYn(), jaeryoGubun, startNum, Integer.parseInt(offset));
		 DrugServiceProto.DRGOCSCHKGrdOcsChkFullResponse.Builder response = DrugServiceProto.DRGOCSCHKGrdOcsChkFullResponse.newBuilder();
         if(!CollectionUtils.isEmpty(listGrdOcsChkFullInfos)) {
         	for(DRGOCSCHKGrdOcsChkFullInfo item : listGrdOcsChkFullInfos) {
         		DrugModelProto.DRGOCSCHKGrdOcsChkFullInfo.Builder info = DrugModelProto.DRGOCSCHKGrdOcsChkFullInfo.newBuilder();
         		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
         		response.addListItem(info);
         	}
         }
		return response.build();
	}

}
