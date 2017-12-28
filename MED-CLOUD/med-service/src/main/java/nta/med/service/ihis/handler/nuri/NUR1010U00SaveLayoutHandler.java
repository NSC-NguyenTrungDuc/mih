package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.nur.Nur1010;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1010Repository;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010U00SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NUR1010U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {   
	
	@Resource
	private Nur1010Repository nur1010Repository;

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010U00SaveLayoutRequest request) throws Exception {
				
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();		
		response.setResult(true);
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = request.getUserId();
		
		List<NuriModelProto.NUR1010U00grdNur1010Info> listItem = request.getGrdNur1010List();		
		if(CollectionUtils.isEmpty(listItem)) {
			response.setResult(false);
			return response.build();
		}
		
		for(NuriModelProto.NUR1010U00grdNur1010Info item : listItem){
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
				insertNur1010(hospCode, userId, item);
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
				if(nur1010Repository.nur1010U00SaveLayoutUpdate(hospCode, userId, item.getDamdangNurse(), CommonUtils.parseDouble(item.getFkinp1001()),
						item.getBunho(), item.getJukyongDate()) < 0){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				if(nur1010Repository.nur1010U00SaveLayoutDelete(hospCode, CommonUtils.parseDouble(item.getFkinp1001()),
						item.getBunho(), item.getJukyongDate()) < 0){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
		}
		
		return response.build();
	}
	
	private void insertNur1010(String hospCode, String userId, NuriModelProto.NUR1010U00grdNur1010Info item){
		Nur1010 nur1010 = new Nur1010();
		
		nur1010.setSysDate(new Date());
		nur1010.setSysId(userId);
		nur1010.setUpdDate(new Date());
		nur1010.setUpdId(userId);
		nur1010.setHospCode(hospCode);
		nur1010.setBunho(item.getBunho());
		nur1010.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
		nur1010.setJukyongDate(DateUtil.toDate(item.getJukyongDate(), DateUtil.PATTERN_YYMMDD));
		nur1010.setDamdangNurse(item.getDamdangNurse());
		
		nur1010Repository.save(nur1010);
	}
}
