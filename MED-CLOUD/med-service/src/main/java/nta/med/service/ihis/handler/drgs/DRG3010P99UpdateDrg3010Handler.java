package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99UpdateDrg3010Handler extends ScreenHandler<DrgsServiceProto.DRG3010P99UpdateDrg3010Request, SystemServiceProto.UpdateResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99UpdateDrg3010Request request) throws Exception{
	
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		Integer result;
		
		switch(request.getNameControl()){
		case "pkdrg5010":
			result = drg3010Repository.DRG3010P99UpdateDrg3010Fkjihkey(hospCode, CommonUtils.parseDouble(request.getPkdrg5010()), request.getJubsuDate(),
					CommonUtils.parseDouble(request.getDrgBunho()), request.getBunho(), "1");
			break;
		case "pkdrg5030":
			result = drg3010Repository.DRG3010P99UpdateDrg3010Fkjihkey(hospCode, CommonUtils.parseDouble(request.getPkdrg5010()), request.getJubsuDate(),
					CommonUtils.parseDouble(request.getDrgBunho()), request.getBunho(), "2");
			break;
		case "drg_pack_yn":
			result = drg3010Repository.DRG3010P99UpdateDrg3010DrgPackYn(hospCode, CommonUtils.parseDouble(request.getFkocs2003()), request.getDrgPackYn());
			break;
		case "powder_yn":
			result = drg3010Repository.DRG3010P99UpdateDrg3010PowderYn(hospCode, CommonUtils.parseDouble(request.getFkocs2003()), request.getPowderYn());
			break;
		case "pkdrg4010":
			result = drg3010Repository.DRG3010P99UpdateDrg3010fkDrg4010(hospCode, CommonUtils.parseDouble(request.getPkdrg4010()), request.getJubsuDate(),
					CommonUtils.parseDouble(request.getDrgBunho()), request.getBunho());
			break;
		default:
			result = drg3010Repository.DRG3010P99UpdateDrg3010ReUseYn(hospCode, CommonUtils.parseDouble(request.getFkocs2003()), request.getReUseYn());
			break;
		}
		
		if(result > 0){
			response.setResult(true);
		}else{
			response.setResult(false);
		}
		
		return response.build();
	}
}