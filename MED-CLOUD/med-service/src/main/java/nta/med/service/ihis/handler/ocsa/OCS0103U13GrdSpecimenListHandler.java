package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdSpecimenListInfo;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13GrdSpecimenListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13GrdSpecimenListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U13GrdSpecimenListHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U13GrdSpecimenListRequest, OcsaServiceProto.OCS0103U13GrdSpecimenListResponse> {                             
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;  
	@Resource
	private Adm0000Repository adm0000Repository;
	
	@Override     
	@Transactional(readOnly = true)
	public OCS0103U13GrdSpecimenListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U13GrdSpecimenListRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U13GrdSpecimenListResponse.Builder response = OcsaServiceProto.OCS0103U13GrdSpecimenListResponse.newBuilder();    
  	   	String offset =  "0" ;
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getOffset())){
			offset = request.getOffset();
		}
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		
		String searchWord = request.getSearchWord(); 
		if (Language.JAPANESE.toString().equalsIgnoreCase(getLanguage(vertx, sessionId))) {
			searchWord = adm0000Repository.callFnAdmConvertKanaFull(hospCode, searchWord);
		}
		
		List<OCS0103U13GrdSpecimenListInfo> listGrdSpecimen = ocs0103Repository.getOCS0103U13GrdSpecimenListInfo(hospCode,
				request.getCplCodeYn(), request.getMode(),request.getSlipCode(), searchWord, request.getWonnaeDrgYn() ,
			DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), request.getInputTab(), request.getUser(), request.getProtocolId(), startNum, Integer.parseInt(offset));
		
		if(!CollectionUtils.isEmpty(listGrdSpecimen)){
			for(OCS0103U13GrdSpecimenListInfo item :listGrdSpecimen){
				OcsaModelProto.OCS0103U13GrdSpecimenListInfo.Builder info = OcsaModelProto.OCS0103U13GrdSpecimenListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getSeq() !=null) {
					info.setSeq(String.format("%.0f",item.getSeq()));
				}
				response.addGrdSpecItem(info);
			}
		}
		return response.build();
	}

}