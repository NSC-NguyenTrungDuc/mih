package nta.med.service.ihis.handler.system;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.inv.Inv0001Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.invs.CheckRemainingInventoryInfo;
import nta.med.data.model.ihis.invs.CountReserveQtyInfo;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemModelProto.OBCheckInventoryParamInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBCheckInventoryRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBCheckInventoryResponse;

@Service                                                                                                          
@Scope("prototype")
public class OBCheckInventoryHandler extends ScreenHandler<SystemServiceProto.OBCheckInventoryRequest, SystemServiceProto.OBCheckInventoryResponse> {                     
	@Resource                                                                                                       
	private Inv0110Repository inv0110Repository;
	@Resource                                                                                                       
	private Inv0001Repository inv0001Repository;
	@Resource                                                                                                       
	private CommonRepository commonRepository;

	@Override
	@Transactional(readOnly = true)
	public OBCheckInventoryResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OBCheckInventoryRequest request) throws Exception {
		SystemServiceProto.OBCheckInventoryResponse.Builder response = SystemServiceProto.OBCheckInventoryResponse.newBuilder();
		List<OBCheckInventoryParamInfo> inventorys = request.getCheckListList();
		List<String> hangmogCodes = new ArrayList<String>();
		List<Double> fkocs1003s = new ArrayList<Double>();
		String hospCode = getHospitalCode(vertx, sessionId);
		Map<String, OBCheckInventoryParamInfo> mapCheckInventory = new HashMap<String, OBCheckInventoryParamInfo>();
		Map<Double, Double> mapCheckReserveQty = new HashMap<Double, Double>();
		if(!CollectionUtils.isEmpty(inventorys)){
			for(OBCheckInventoryParamInfo item : inventorys){
				hangmogCodes.add(item.getHangmogCode());
				if(!StringUtils.isEmpty(item.getPkocs1003())){
					fkocs1003s.add(CommonUtils.parseDouble(item.getPkocs1003()));
				}
				mapCheckInventory.put(item.getHangmogCode(), item);
			}
		}
		// case update reserve qty in table INV0001
		if(!CollectionUtils.isEmpty(fkocs1003s)){
			List<CountReserveQtyInfo> reserveQtys = inv0001Repository.countReserveQtyByFkocs1003(hospCode, fkocs1003s);
			if(!CollectionUtils.isEmpty(reserveQtys)){
				for(CountReserveQtyInfo item : reserveQtys){
					mapCheckReserveQty.put(item.getFkocs1003(), item.getReserveQty() == null ? new Double(0) : item.getReserveQty());
				}
			}
		}
		List<CheckRemainingInventoryInfo> remainings = inv0110Repository.checkRemainingInventory(hospCode, hangmogCodes);
		if(!CollectionUtils.isEmpty(remainings)){
			for(CheckRemainingInventoryInfo item : remainings){
				OBCheckInventoryParamInfo invenParam = mapCheckInventory.get(item.getHangmogCode());
				if(invenParam != null){
					Double dv = CommonUtils.parseDouble(StringUtils.isEmpty(invenParam.getDv()) ? "1" : invenParam.getDv());
					Double nalsu = CommonUtils.parseDouble(StringUtils.isEmpty(invenParam.getNalsu()) ? "1" : invenParam.getNalsu());
					Double suryang = CommonUtils.parseDouble(StringUtils.isEmpty(invenParam.getSuryang()) ? "1" : invenParam.getSuryang());
					String fkocs1003 = invenParam.getPkocs1003();
					Double revertReverveQty = new Double(0); // case revertReverveQty = 0 means no update qty other means update
					if(!StringUtils.isEmpty(fkocs1003)){
						revertReverveQty = mapCheckReserveQty.get(CommonUtils.parseDouble(fkocs1003)) == null ? new Double(0) : mapCheckReserveQty.get(CommonUtils.parseDouble(fkocs1003));
					}
					// CHECK  INV4002   2004  inv0001    INSERT QUANTITY
					//Double qty = item.getJaeryoQty() - item.getReverveQty() + revertReverveQty - (suryang * dv * nalsu);
					Double qty = item.getJaeryoQty() - item.getReverveQty() + revertReverveQty - (commonRepository.callFnDrgWonyoiTotSurang(nalsu, suryang, dv, invenParam.getDvTime()));
					Double qtyInStock = item.getJaeryoQty() - item.getReverveQty() + revertReverveQty;
					if(qty < 0){
						SystemModelProto.OBCheckInventoryInfo.Builder info =SystemModelProto.OBCheckInventoryInfo.newBuilder();
						if(!StringUtils.isEmpty(item.getHangmogCode())){
							info.setHangmogCode(item.getHangmogCode());
						}
						if(!StringUtils.isEmpty(item.getHangmogName())){
							info.setHangmogName(item.getHangmogName());
						}
						if(qtyInStock != null){
							info.setQuantity(String.format("%.0f", qtyInStock));
						}
						response.addOutputList(info);
					}
				}
				
			}
		}
		return response.build();
	}

}
