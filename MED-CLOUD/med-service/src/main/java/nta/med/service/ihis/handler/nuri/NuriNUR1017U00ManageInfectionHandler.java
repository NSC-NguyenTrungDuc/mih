package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.data.model.ihis.nuri.NuriNUR1017U00ManageInfectionInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;
@Service
@Scope("prototype")
public class NuriNUR1017U00ManageInfectionHandler  extends ScreenHandler<NuriServiceProto.NuriNUR1017U00ManageInfectionRequest,  NuriServiceProto.NuriNUR1017U00ManageInfectionResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuriNUR1017U00ManageInfectionHandler.class);
	
	@Resource
	private Nur1017Repository nur1017Repository;

	@Override
	@Transactional(readOnly = true)
	public  NuriServiceProto.NuriNUR1017U00ManageInfectionResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1017U00ManageInfectionRequest request) throws Exception {
		NuriServiceProto.NuriNUR1017U00ManageInfectionResponse.Builder response = NuriServiceProto.NuriNUR1017U00ManageInfectionResponse.newBuilder();
		List<NuriNUR1017U00ManageInfectionInfo> listNuriNUR1017U00ManageInfectionInfo = nur1017Repository.getNuriNUR1017U00ManageInfectionInfo(getHospitalCode(vertx, sessionId), request.getBunho());
		if(listNuriNUR1017U00ManageInfectionInfo != null && !listNuriNUR1017U00ManageInfectionInfo.isEmpty()){
       	 for(NuriNUR1017U00ManageInfectionInfo item : listNuriNUR1017U00ManageInfectionInfo){
       		 NuriModelProto.NuriNUR1017U00ManageInfectionInfo.Builder nuriManageInfectionInfo = NuriModelProto.NuriNUR1017U00ManageInfectionInfo.newBuilder();

       		 if(item.getInfeCode()!= null){
       			 nuriManageInfectionInfo.setInfeCode(item.getInfeCode());
       		 }
       		 if(item.getBunho()!= null){
       			 nuriManageInfectionInfo.setBunho(item.getBunho());
       		 }
       		 if(item.getStartDate()!= null){
       			 nuriManageInfectionInfo.setStartDate(item.getStartDate());
       		 }
       		 if(item.getEndDate()!= null){
       			 nuriManageInfectionInfo.setEndDate(item.getEndDate());
       		 }
       		 if(item.getInfeFaeryo()!= null){
       			 nuriManageInfectionInfo.setInfeJaeryo(item.getInfeFaeryo());
       		 }
       		 if(item.getEndSayu()!= null){
       			 nuriManageInfectionInfo.setEndSayu(item.getEndSayu());
       		 }
       		 if(item.getInputText()!= null){
       			 nuriManageInfectionInfo.setInputText(item.getInputText());
       		 }
       		 if(item.getPknur1017()!= null){
       			 nuriManageInfectionInfo.setPknur1017(item.getPknur1017());
       		 }
       		 
       		 response.addManageInfectionItem(nuriManageInfectionInfo);
       	 }
        }
		return response.build();
	}
}
