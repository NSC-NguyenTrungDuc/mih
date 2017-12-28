package nta.med.service.ihis.handler.invs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inv.Inv6002;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv6002Repository;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00GrdINV6002ExcuteRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class INV6002U00GrdINV6002ExcuteHandler
		extends ScreenHandler<InvsServiceProto.INV6002U00GrdINV6002ExcuteRequest, SystemServiceProto.UpdateResponse> {

	@Resource
    private Inv6002Repository inv6002Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV6002U00GrdINV6002ExcuteRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<InvsModelProto.INV6002U00GrdINV6002ExcuteInfo> itemList = request.getItemList();
		if(CollectionUtils.isEmpty(itemList)){
			response.setResult(false);
			return response.build();
		}
		
		String hospCode = getHospitalCode(vertx, sessionId);
		for (InvsModelProto.INV6002U00GrdINV6002ExcuteInfo info : itemList) {
			if(info.hasJaeryoCode()){
				String magamMonth = info.getMagamMonth() == null ? "" : info.getMagamMonth(); 
				List<Inv6002> inv6002List = inv6002Repository.findByHospCodeMagamMonthJaeryoCode(hospCode, magamMonth, info.getJaeryoCode());
				Inv6002 inv = null;
				if(CollectionUtils.isEmpty(inv6002List)){
					inv = insertInv6002(info, hospCode);
				} else {
					inv = updateInv6002(inv6002List.get(0), CommonUtils.parseDouble(info.getExistCount()), info.getUserId(), info.getInputUser());
				}
				
				if(inv == null || inv.getId() == null){
					throw new ExecutionException(response.setResult(false).build());
				}
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private Inv6002 insertInv6002(InvsModelProto.INV6002U00GrdINV6002ExcuteInfo info, String hospCode){
		Inv6002 inv6002 = new Inv6002();
		inv6002.setSysDate(new Date());
		inv6002.setSysId(info.getUserId());
		inv6002.setHospCode(hospCode);
		inv6002.setMagamMonth(info.getMagamMonth());
		inv6002.setJaeryoCode(info.getJaeryoCode());
		inv6002.setExistCount(CommonUtils.parseDouble(info.getExistCount()));
		inv6002.setInputDate(DateUtil.toDate(info.getInputDate(), DateUtil.PATTERN_YYMMDD));
		inv6002.setInputUser(info.getInputUser());
		
		inv6002Repository.save(inv6002);
		return inv6002;
	}
	
	private Inv6002 updateInv6002(Inv6002 inv6002, Double newExistCount, String newUpdId, String inputUser){
		inv6002.setExistCount(newExistCount);
		inv6002.setUpdDate(new Date());
		inv6002.setUpdId(newUpdId);
		inv6002.setInputUser(inputUser);
		
		inv6002Repository.save(inv6002);
		return inv6002;
	}
}
