package nta.med.service.ihis.handler.nuro;

import java.util.ArrayList;
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

import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.DataStringListItemInfo;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
@Transactional(readOnly = true)
public class NUR1001R98LayReserInfoQueryEndHandler extends ScreenHandler<NuroServiceProto.NUR1001R98LayReserInfoQueryEndRequest, NuroServiceProto.NUR1001R98LayReserInfoQueryEndResponse>{
	private static final Log LOGGER = LogFactory.getLog(NUR1001R98LayReserInfoQueryEndHandler.class);
	@Resource
	private Out1001Repository out1001Repository;
	@Resource
	private Bas0001Repository bas0001Repository;
	@Resource
	private Sch0109Repository sch0109Repository;
	
	@Override
	public NuroServiceProto.NUR1001R98LayReserInfoQueryEndResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NUR1001R98LayReserInfoQueryEndRequest request) throws Exception {
		NuroServiceProto.NUR1001R98LayReserInfoQueryEndResponse.Builder response = NuroServiceProto.NUR1001R98LayReserInfoQueryEndResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//get NuroInspectionOrderGetReserMoveNameRequest
    	for(int i=0 ;i < request.getDepartmentCodeCount();i++ ){
    		List<String> getReserMoveName = out1001Repository.getInspectionOrderReserMoveName(hospCode, language, request.getPatientCode(), request.getReserDate(),
    				request.getDepartmentCode(i).getDataValue(),
            		request.getReserYn(), request.getRowNum());
    		if (getReserMoveName != null && !getReserMoveName.isEmpty()) {
                 for (String obj : getReserMoveName) {	
                	 CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
                	 if(!StringUtils.isEmpty(obj)){
                		 info.setDataValue(obj);
                	 }
                	 response.addReserMoveName(info);
                	
                 }
             }
    	}            	
    	//get  NuroInspectionOrderGetTelRequest
    	 List<String> listTel = bas0001Repository.getNuroInspectionOrderGetTel(hospCode, request.getReserDate());
    	 if (listTel != null && !listTel.isEmpty()) {
             for (String tel : listTel) {
            	 if(!StringUtils.isEmpty(tel)){
            		 response.setTelItem(tel);
            	 }
             }
         }
    	
    	 List<String> listResertParts = null;
    	 if(!CollectionUtils.isEmpty(request.getReserPartList())){
    		 listResertParts = new ArrayList<String>();
    		 for(DataStringListItemInfo reserpart : request.getReserPartList()){
    			 if(!StringUtils.isEmpty(reserpart.getDataValue())){
    				 listResertParts.add(reserpart.getDataValue());
    			 }
    		 
    		 }
    	 }
    	 //get NuroInspectionOrderGetMaxCodeNameRequest
    	 List<String> listMaxCode = sch0109Repository.getNuroInspectionOrderMaxCodeName(hospCode, request.getCodeType(), listResertParts);
    	 if (listMaxCode != null && !listMaxCode.isEmpty()) {
             for (String maxCode : listMaxCode) {
            	 CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
            	 if(!StringUtils.isEmpty(maxCode)){
            		 info.setDataValue(maxCode);
            	 }
            	 response.addCodeNameItem(info);
             }
         }
    	 //get NuroInspectionOrderGetInfoTextRequest
    	 List<String> listInfoText = sch0109Repository.getNuroInspectionOrderText(hospCode, request.getCodeTypeGetInfoText(), getLanguage(vertx, sessionId));
    	 if (listInfoText != null && !listInfoText.isEmpty()) {
             for (String infoText : listInfoText) {
            	 CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
            	 if(!StringUtils.isEmpty(infoText)){
            		 info.setDataValue(infoText);
            	 }
            	 response.addInfoTextItem(info);  
             }
         }
		return response.build();
	}
}
