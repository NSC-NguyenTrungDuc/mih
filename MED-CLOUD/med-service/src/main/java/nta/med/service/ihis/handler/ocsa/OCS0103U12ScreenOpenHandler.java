package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.data.dao.medi.ocs.Ocs1024Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.ComboDataSourceInfo;
import nta.med.service.ihis.proto.CommonModelProto.OcsOrderBizGetUserOptionInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12ScreenOpenRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12ScreenOpenResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12ScreenOpenHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12ScreenOpenRequest, OcsaServiceProto.OCS0103U12ScreenOpenResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12ScreenOpenHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;  
	
	@Resource
	private Ocs0132Repository ocs0132Repository;

	@Resource
	private Ocs1024Repository ocs1024Repository;
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)                                                                                           
	public OCS0103U12ScreenOpenResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U12ScreenOpenRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U12ScreenOpenResponse.Builder response = OcsaServiceProto.OCS0103U12ScreenOpenResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		OcsOrderBizGetUserOptionInfo item  = request.getGetUserOption();
		if(item != null){
			String userResult = ocs0150Repository.callFnOcsUserOptionInfo(hospCode, item.getDoctor(), item.getGwa(), 
					item.getKeyword(), item.getIoGubun());
			if(!StringUtils.isEmpty(userResult)){
				response.setUserOptionResult(userResult);
			}
		}
		
		for(ComboDataSourceInfo comboItem : request.getComboInfoList()){
			if(comboItem.getColName().equalsIgnoreCase("order_gubun_bas")){
				//order_gubun_bas
				List<ComboListItemInfo> listOrderGubun = ocs0132Repository.getComboDataSourceInfoCaseOrderGubunBas(hospCode, language);
				if(!CollectionUtils.isEmpty(listOrderGubun)){
					for(ComboListItemInfo Object : listOrderGubun){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(Object, info, getLanguage(vertx, sessionId));
						response.addCboOrderGubunBas(info);
					}
				}
			}else if(comboItem.getColName().equalsIgnoreCase("dv_time")){
				//Dv_time
				List<ComboListItemInfo> listDvTime = ocs0132Repository.getOCS0103U12CboDvTimeListItemInfo(hospCode, "#", "DV_TIME", language);
				if(!CollectionUtils.isEmpty(listDvTime)){
					for(ComboListItemInfo Object : listDvTime){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(Object, info, getLanguage(vertx, sessionId));
						response.addCboDvTime(info);
					}
				}
			}else if(comboItem.getColName().equalsIgnoreCase("suryang")){
				//suryang
				List<ComboListItemInfo> listSuryang = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", "SURYANG", language);
				if(!CollectionUtils.isEmpty(listSuryang)){
					for(ComboListItemInfo Object : listSuryang){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(Object, info, getLanguage(vertx, sessionId));
						response.addCboSuryang(info);
					}
				}
			}else if(comboItem.getColName().equalsIgnoreCase("dv")){
				//Dv
				List<ComboListItemInfo> listDv = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", "DV", language);
				if(!CollectionUtils.isEmpty(listDv)){
					for(ComboListItemInfo Object : listDv){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(Object, info, getLanguage(vertx, sessionId));
						response.addCboDv(info);
					}
				}
			}else if(comboItem.getColName().equalsIgnoreCase("nalsu")){
				//Nalsu
				List<ComboListItemInfo> listNalsu = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospCode, "%", "NALSU", language);
				if(!CollectionUtils.isEmpty(listNalsu)){
					for(ComboListItemInfo Object : listNalsu){
						CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
						BeanUtils.copyProperties(Object, info, getLanguage(vertx, sessionId));
						response.addCboNalsu(info);
					}
				}
			}
		}
		
		String ynResult = ocs1024Repository.callFnOcsIsBroughtDrgYn(hospCode, request.getBunho(),CommonUtils.parseInteger(request.getPkinp1001()), request.getInputTab());
		if(!StringUtils.isEmpty(ynResult)){
			response.setYnValue(ynResult);
		}
		return response.build();
	}

}