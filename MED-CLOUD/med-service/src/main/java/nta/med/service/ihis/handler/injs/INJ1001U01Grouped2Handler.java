package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.nur.Nur1017;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;
                 
@Service
@Scope("prototype")  
public class INJ1001U01Grouped2Handler extends ScreenHandler<InjsServiceProto.INJ1001U01Grouped2Request, InjsServiceProto.INJ1001U01Grouped2Response> {                             
	private static final Log LOGGER = LogFactory.getLog(INJ1001U01Grouped2Handler.class);                                        
	@Resource
	private Nur1017Repository nur1017Repository;
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;
	@Resource                                                                                                       
	private Nur1016Repository nur1016Repository;                                                                                                                

	@Override
	public boolean isValid(InjsServiceProto.INJ1001U01Grouped2Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getQueryDate()) && DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01Grouped2Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01Grouped2Request  request) throws Exception {
		InjsServiceProto.INJ1001U01Grouped2Response.Builder response = InjsServiceProto.INJ1001U01Grouped2Response.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		//get InjsINJ1001U01InfectionListItemInfo 
            List<Nur1017> listObject = nur1017Repository.getInjsINJ1001U01InfectionListItemInfo(hospitalCode, request.getBunho(), DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD));
            if (!CollectionUtils.isEmpty(listObject)) { 	
            	for (Nur1017 item : listObject) {
            		InjsModelProto.InjsINJ1001U01InfectionListItemInfo.Builder info =  InjsModelProto.InjsINJ1001U01InfectionListItemInfo.newBuilder();
            		if(!StringUtils.isEmpty(item.getInfeJaeryo())) {
            			info.setInfeJaeryo(item.getInfeJaeryo());
            		}
            		if(!StringUtils.isEmpty(item.getInfeCode())) {
            			info.setInfeCode(item.getInfeCode());
            		}
            		response.addGrdNur1017ListItem(info);	
            	}
            }
        
		//get InjsINJ1001U01CommentListRequest 
		List<String> listComments =out0106Repository.findCommentsByBunhoAndCmmtGubun(hospitalCode,request.getBunho(),request.getCommtGubun());
		if(!CollectionUtils.isEmpty(listComments)){
			for(String item : listComments){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item)) {
					info.setDataValue(item);
				}
				response.addGrdOut0106ListItem(info);
			}
		}
		//get InjsINJ1001U01AllergyListRequest 
		List<String> listAllergy =nur1016Repository.getInjsINJ1001U01AllergyList(hospitalCode,request.getBunho(),DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD) );
		if(!CollectionUtils.isEmpty(listAllergy)){
			for(String item : listAllergy){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item)) {
					info.setDataValue(item);
				}
				response.addGrdNur1016ListItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}