package nta.med.service.orca.handler;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inp.Inp1008;
import nta.med.core.domain.out.Out1002;
import nta.med.core.glossary.InOutType;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1002Repository;
import nta.med.data.dao.medi.inp.Inp1008Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.Out1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto.ORDERTRANProcessRequiInfo;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.ORDERTRANProcessRequiRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class ORDERTRANProcessRequiHandler extends ScreenHandler<NuroServiceProto.ORDERTRANProcessRequiRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANProcessRequiHandler.class);                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;   
	@Resource
	private Inp1001Repository inp1001Repository;
	@Resource
	private Inp1002Repository inp1002Repository;
	@Resource
	private Out1002Repository out1002Repository;
	@Resource
	private Inp1008Repository inp1008Repository;
	                                                                                                               
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ORDERTRANProcessRequiRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<ORDERTRANProcessRequiInfo> listProcess = request.getInputListList();
		Integer result = null;
		boolean insertResult = false;
		List<String> retVal = null;
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!CollectionUtils.isEmpty(listProcess)){
			for(ORDERTRANProcessRequiInfo item : listProcess){
				Double pk1001 = CommonUtils.parseDouble(item.getPk1001());
				if(InOutType.OUT.getValue().equals(item.getIoGubun())){
					result = out1001Repository.oRDERTRANProcessRequiUpdateOut1001(hospCode, item.getGubun(), 
							item.getChojae(), item.getSanjungGubun(), pk1001);
					if(result <= 0){
						response.setMsg("Not found item on OUT1001");
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					//SetProcessGongbi
					retVal = out1002Repository.getYByPkout1001(hospCode, pk1001);
					if(!CollectionUtils.isEmpty(retVal)){
						result = out1002Repository.deleteOut1002ById(hospCode, item.getPk1001());
						if(result <= 0){
							response.setMsg("Not found item on OUT1002");
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
					}
					insertResult = insertOut1001(item, hospCode);
				}else{
					result = inp1001Repository.oRDERTRANProcessRequiUpdateInp1001(hospCode, pk1001);
					if(result <= 0){
						response.setResult(false);
						response.setMsg("Not found item on INP1001");
						throw new ExecutionException(response.build());
					}
					if(InOutType.IN.getValue().equals(item.getIoGubun())){
						result = inp1002Repository.oRDERTRANProcessRequiUpdateInp1002(hospCode, item.getGubun(), pk1001, item.getPkinp1002());
						if(result <= 0){
							response.setResult(false);
							response.setMsg("Not found item on INP1002");
							throw new ExecutionException(response.build());
						}
					}
					//SetProcessGongbi
					retVal = inp1008Repository.getYByPkinp1002(hospCode, item.getPkinp1002());
					if(!CollectionUtils.isEmpty(retVal)){
						result = inp1008Repository.deleteInp1008ByPkout1001(hospCode, item.getPkinp1002());
						if(result <= 0){
							response.setMsg("Not found item on INP1008");
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
					}
					insertResult = insertInp1008(item, hospCode);
				}
			}
		}
		response.setResult(insertResult);
		return response.build();
	}
	
	public boolean insertOut1001(ORDERTRANProcessRequiInfo info, String hospCode){
		Out1002 out1002 = new Out1002();
		Double priority = CommonUtils.parseDouble(info.getPriority());
		out1002.setSysDate(new Date());
		out1002.setSysId(info.getSysId());
		out1002.setHospCode(hospCode);
		out1002.setFkout1001(info.getPk1001());
		out1002.setPriority(priority);
		out1002Repository.save(out1002);
		return true;
	}
	public boolean insertInp1008(ORDERTRANProcessRequiInfo info, String hospCode){
		Inp1008 inp1008 = new Inp1008();
		Double priority = CommonUtils.parseDouble(info.getPriority());
		inp1008.setSysDate(new Date());
		inp1008.setSysId(info.getSysId());
		inp1008.setHospCode(hospCode);
		inp1008.setFkinp1002(info.getPkinp1002());
		inp1008.setPriority(priority);
		inp1008Repository.save(inp1008);
		return true;
	}
}