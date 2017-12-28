package nta.med.service.ihis.handler.bass;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.bas.Bas0111;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0111Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.BAS0111U00GrdBas0111ItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0111U00SaveLayoutRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0111U00SaveLayoutResponse;

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
@Transactional
public class BAS0111U00SaveLayoutHandler extends ScreenHandler<BassServiceProto.BAS0111U00SaveLayoutRequest, BassServiceProto.BAS0111U00SaveLayoutResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(BAS0111U00SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Bas0111Repository bas0111Repository;  
	@Resource
	private Bas0102Repository bas0102Repository;
	                                                                                                                
	@Override
	public BAS0111U00SaveLayoutResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0111U00SaveLayoutRequest request) throws Exception {
		BassServiceProto.BAS0111U00SaveLayoutResponse.Builder response = BassServiceProto.BAS0111U00SaveLayoutResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Integer result = null;
		List<BAS0111U00GrdBas0111ItemInfo> listItem = request.getGrdItemList();
		if(!CollectionUtils.isEmpty(listItem)){
			for(BAS0111U00GrdBas0111ItemInfo item : listItem){
				if(DataRowState.ADDED.getValue().equals(item.getRowState())){
					String getY = bas0111Repository.getY(hospCode, item.getJohapGubun(), item.getJohap(), item.getGaein());
					if(!StringUtils.isEmpty(getY)){
						response.setJohapGubun(item.getJohapGubun());
						response.setJohap(item.getJohap());
						response.setGaein(item.getGaein());
						response.setErrFlag("1");
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					List<Bas0102> listBas0102 = bas0102Repository.getByCodeAndCodeType(hospCode, item.getJohapGubun(), "JOHAP_GUBUN", language);
					if(!CollectionUtils.isEmpty(listBas0102)){
						String codeName = listBas0102.get(0).getCodeName();
						if(StringUtils.isEmpty(codeName)){
							response.setJohapGubun(item.getJohapGubun());
							response.setErrFlag("2");
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
					}
					Bas0111 bas0111 = new Bas0111();
					bas0111.setSysDate(new Date());
					bas0111.setSysId(request.getQUserId());
					bas0111.setUpdDate(new Date());
					bas0111.setUpdId(request.getQUserId());
					bas0111.setHospCode(hospCode);
					if(!StringUtils.isEmpty(item.getJohap())){
						bas0111.setJohap(item.getJohap());
					}
					if(!StringUtils.isEmpty(item.getGaein())){
						bas0111.setGaein(item.getGaein());
					}
					if(!StringUtils.isEmpty(item.getJohapGubun())){
						bas0111.setJohapGubun(item.getJohapGubun());
					}
					bas0111.setUseYn(item.getUseYn());
					bas0111.setZipCode1(item.getZipCode1());
					bas0111.setZipCode2(item.getZipCode2());
					bas0111.setAddress(item.getAddress());
					bas0111.setAddress1(item.getAddress1());
					bas0111.setGaeinName(item.getName()); // gaeinName = item.getName in grid
					
					bas0111Repository.save(bas0111);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())){
					List<Bas0102> listBas0102 = bas0102Repository.getByCodeAndCodeType(hospCode, item.getJohapGubun(), "JOHAP_GUBUN", language);
					if(!CollectionUtils.isEmpty(listBas0102)){
						String codeName = listBas0102.get(0).getCodeName();
						if(StringUtils.isEmpty(codeName)){
							response.setJohapGubun(item.getJohapGubun());
							response.setErrFlag("3");
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
					}
					result = bas0111Repository.updateBas0111(hospCode, request.getQUserId(), new Date(), item.getUseYn(),
							item.getZipCode1(), item.getZipCode2(), item.getAddress(),
							item.getAddress1(), item.getJohapGubun(), item.getJohap(), item.getGaein());
					if(result <= 0){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				} else if(DataRowState.DELETED.getValue().equals(item.getRowState())){
					result = bas0111Repository.deleteBas0111(hospCode, item.getJohapGubun(), item.getJohap(), item.getGaein());
					if(result <= 0){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}
		response.setResult(true);
		return response.build();
	}                                                                                                                 
}