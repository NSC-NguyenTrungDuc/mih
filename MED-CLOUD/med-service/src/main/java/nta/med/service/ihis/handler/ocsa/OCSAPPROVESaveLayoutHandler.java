package nta.med.service.ihis.handler.ocsa;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs1003;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCSAPPROVEGrdOrderInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAPPROVESaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSAPPROVESaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OCSAPPROVESaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;         
	
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository; 
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, OCSAPPROVESaveLayoutRequest request) throws Exception {                                                                  
	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();       
	   	String hospCode = getHospitalCode(vertx, sessionId);
	   	boolean save = false;
	   	
		for(OCSAPPROVEGrdOrderInfo item : request.getGrdListList()){
			if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
				if(item.getSelectValue().equalsIgnoreCase("Y")){
					if(request.getSelectedIogubun().equalsIgnoreCase("O")){
						save = updateOcs1003(item, request.getUserId(),hospCode);
					}else{
						save = updateOcs2003(item, request.getUserId(), hospCode);
					}
					
					if(!save){
						response.setResult(false);
						throw new ExecutionException(response.build());
					} 
				}
			}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
				if(request.getSelectedIogubun().equalsIgnoreCase("O")){
					save = deleteOcs1003(item, hospCode);
				}else{
					save = deleteOcs2003(item, hospCode);
				}
				
				if(!save){
					response.setResult(false);
					throw new ExecutionException(response.build());
				} 
			}else if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
				response.setResult(false);
				throw new ExecutionException(response.build());
			}
		}
		
		response.setResult(true);
		return response.build();
	}   
	
	public boolean updateOcs1003(OCSAPPROVEGrdOrderInfo item, String userId, String hospCode){
		List<Ocs1003> ocs1003List = ocs1003Repository.findByHospCodeAndPk(hospCode, Double.valueOf(item.getPkocs1003()));
		if(CollectionUtils.isEmpty(ocs1003List)){
			return false;
		}
		
		if(ocs1003List.get(0).getActingDate() != null){
			return ocs1003Repository.updateOCSAPPROVEOcs1003(
					userId, 
					item.getJundalPartOut(), 
					item.getJundalTableOut(), 
					item.getMovePartOut(), 
					item.getInputGubun(), 
					CommonUtils.parseDouble(item.getNalsu()), 
					CommonUtils.parseDouble(item.getSuryang()),
					CommonUtils.parseDouble(item.getDv()),
					userId, 
					userId, 
					item.getMuhyo(), 
					hospCode, 
					CommonUtils.parseDouble(item.getPkocs1003())) > 0;
		}
		
		Date actingDate = DateUtil.toDate(new SimpleDateFormat(DateUtil.PATTERN_YYMMDD).format(new Date()), DateUtil.PATTERN_YYMMDD);
		
		return ocs1003Repository.approveOrderOcs1003(
				userId, 
				item.getJundalPartOut(), 
				item.getJundalTableOut(), 
				item.getMovePartOut(), 
				item.getInputGubun(), 
				CommonUtils.parseDouble(item.getNalsu()), 
				CommonUtils.parseDouble(item.getSuryang()),
				CommonUtils.parseDouble(item.getDv()),
				userId, 
				actingDate,
				userId, 
				item.getMuhyo(), 
				hospCode, 
				CommonUtils.parseDouble(item.getPkocs1003())) > 0;
	}
	
	public boolean updateOcs2003(OCSAPPROVEGrdOrderInfo item, String userId, String hospCode){
		return ocs2003Repository.updateOCSAPPROVEOcs2003(
				userId, 
				item.getJundalPartOut(), 
				item.getJundalTableOut(), 
				item.getMovePartOut(), 
				item.getInputGubun(), 
				CommonUtils.parseDouble(item.getNalsu()), 
				CommonUtils.parseDouble(item.getSuryang()),
				CommonUtils.parseDouble(item.getDv()),
				userId, 
				userId, 
				item.getMuhyo(), 
				hospCode, 
				CommonUtils.parseDouble(item.getPkocs1003())) > 0;
	}
	
	public boolean deleteOcs1003(OCSAPPROVEGrdOrderInfo item, String hospCode){
		return ocs1003Repository.deleteOcsoOCS1003P01DeleteFromOCS1003(CommonUtils.parseDouble(item.getPkocs1003()),hospCode) > 0;
	}
	
	public boolean deleteOcs2003(OCSAPPROVEGrdOrderInfo item, String hospCode){
		return ocs2003Repository.deleteOCS0103U13SaveLayout(hospCode,CommonUtils.parseDouble(item.getPkocs1003())) > 0;
	}
}