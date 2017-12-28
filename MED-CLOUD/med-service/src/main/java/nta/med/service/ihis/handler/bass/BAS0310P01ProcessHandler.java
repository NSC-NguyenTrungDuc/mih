package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.BAS0310P01ProcType;
import nta.med.core.glossary.ScreenTable;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.dao.medi.cht.Cht0115Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01ProcessRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;


@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0310P01ProcessHandler extends ScreenHandler<BassServiceProto.BAS0310P01ProcessRequest, SystemServiceProto.UpdateResponse> {                    
	@Resource                                                                                                       
	private Cht0110Repository cht0110Repository;  
	
	@Resource                                                                                                       
	private Cht0115Repository cht0115Repository;    
	
	@Resource                                                                                                       
	private Bas0310Repository bas0310Repository;      
	
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;    

	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Override
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01ProcessRequest request)
			throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String ioErr = "1";
		BAS0310P01ProcType type = BAS0310P01ProcType.get(request.getUpdateProcName());
		Bas0001 bas0001 = bas0001Repository.findLatestByHospCode("NTA").get(0);
		String tblChangeRevision = "";
		String curentRevison = bas0001.getRevision();
		
		switch (type){
			case MASTER_SANG:
				ioErr  = cht0110Repository.callPrAdmUpdateMasterSang(hospCode, request.getUserId());
				tblChangeRevision = ScreenTable.MASTER_SANG.getValue();
			break;
			case MASTER_SUSIK:
				ioErr  = cht0115Repository.callPrAdmUpdateMasterSusik(hospCode, request.getUserId(), request.getProcGubun());
				tblChangeRevision = ScreenTable.MASTER_SUSIK.getValue();
			break;
			case MASTER_COM:
				ioErr  = bas0310Repository.callPrAdmUpdateMasterCom(hospCode, request.getUserId(), request.getProcGubun());
				tblChangeRevision = ScreenTable.MASTER_COM.getValue();
			break;
			case MASTER_SAKURA:
				ioErr  = ocs0103Repository.callPrAdmUpdateMasterSakura(hospCode, request.getUserId(), request.getProcGubun());
			break;
			case MASTER_GD:
				ioErr  = ocs0103Repository.callPrAdmUpdateMasterGd(hospCode, request.getUserId(), request.getProcGubun());
				tblChangeRevision = ScreenTable.MASTER_GD.getValue();
			break;
			default:
			break;
		}
		
		if(ioErr.equals("0")){
			String newRevision = CommonUtils.getNewGlobalRevision(curentRevison, tblChangeRevision);
			
			bas0001.setRevision(newRevision);
			bas0001Repository.save(bas0001);
			
			response.setResult(true);
			
		}else{
			response.setResult(false);
		}
		return response.build();
	}                                                                                                                 
}