package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13CboListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13CboListResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U13CboListHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U13CboListRequest, OcsaServiceProto.OCS0103U13CboListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U13CboListHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public OCS0103U13CboListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0103U13CboListRequest request)
			throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U13CboListResponse.Builder response = OcsaServiceProto.OCS0103U13CboListResponse.newBuilder();    
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		for(CommonModelProto.ComboDataSourceInfo item : request.getComboItemListInfoList()){
			switch(item.getColName()) {
			case "nalsu":
				List<ComboListItemInfo> listNalsu= ocs0132Repository.getComboDataSourceInfoByCodeType(hospCode, language,"NALSU", false);
				if(!CollectionUtils.isEmpty(listNalsu)){	
					for(ComboListItemInfo item2 :listNalsu){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item2, info, getLanguage(vertx, sessionId));
						response.addNalsuItem(info);
					}
				}
				break;
			case "suryang":
				List<ComboListItemInfo> listSuryang =ocs0132Repository.getComboDataSourceInfoByCodeType(hospCode, language,"SURYANG", false);
				if(!CollectionUtils.isEmpty(listSuryang)){	
					for(ComboListItemInfo item2 :listSuryang){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item2, info, getLanguage(vertx, sessionId));
						response.addSuryangItem(info);
					}
				}
		    	break;
			case "order_gubun_bas":
				List<ComboListItemInfo> listOrderGubunBas= ocs0132Repository.getComboDataSourceInfoCaseOrderGubunBas(hospCode, language);
				if(!CollectionUtils.isEmpty(listOrderGubunBas)){	
					for(ComboListItemInfo item2 :listOrderGubunBas){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(item2, info, getLanguage(vertx, sessionId));
						response.addOrderGubunBasCboItem(info);
					}
				}
				break;
			}		
		}
		List<ComboListItemInfo> listSearchGubun= ocs0132Repository.getComboDataSourceInfoByCodeTypeOrOrderBy(hospCode, language, "SEARCH_GUBUN", false);
		if(!CollectionUtils.isEmpty(listSearchGubun)){	
			for(ComboListItemInfo item2 :listSearchGubun){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item2, info, getLanguage(vertx, sessionId));
				response.addSearchConditionItem(info);
			}
		}	
		return response.build();
	}
}