package nta.med.service.ihis.handler.nuts;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.nut.Nut0001;
import nta.med.core.domain.nut.Nut0002;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.nut.Nut0001Repository;
import nta.med.data.dao.medi.nut.Nut0002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NutsModelProto.NUT0001U00GrdNUT0001ItemInfo;
import nta.med.service.ihis.proto.NutsModelProto.NUT0001U00GrdNUT0002ItemInfo;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUT0001U00SaveLayoutHandler extends ScreenHandler<NutsServiceProto.NUT0001U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(NUT0001U00SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Nut0001Repository nut0001Repository;       
	@Resource                                                                                                       
	private Nut0002Repository nut0002Repository;    
	@Resource
	private CommonRepository commonRepository;
	                                                                                                                
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NutsServiceProto.NUT0001U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();  
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean nut0001 = false;
		boolean nut0002 = false;
		if(CollectionUtils.isEmpty(request.getGrd001ItemInfoList())){
			nut0001 = true;
		}else{
			for(NUT0001U00GrdNUT0001ItemInfo item : request.getGrd001ItemInfoList()){
				if(!saveNut0001(item, hospCode)){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}else{
					nut0001 = true;
				}
			}
		}
	
		if(CollectionUtils.isEmpty(request.getGrd002ItemInfoList())){
			nut0002 = true;
		}else{
			for(NUT0001U00GrdNUT0002ItemInfo item : request.getGrd002ItemInfoList()){
				if(!saveNut0002(item, hospCode)){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}else{
					nut0002 = true;
				}
			}
		}
		
		if(nut0001 && nut0002){
			response.setResult(true);
		}
		return response.build();
	}
	
	public boolean saveNut0001(NUT0001U00GrdNUT0001ItemInfo item, String hospCode){
		boolean save = false;
		if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
			save = insertNut0001(item, hospCode);
		}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
			save = updateNut0001(item, hospCode);
		}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
			save = deleteNut0001(item);
		}
		return save;
	}
	
	public boolean saveNut0002(NUT0001U00GrdNUT0002ItemInfo item, String hospCode){
		boolean save = false;
		if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
			String pkocs = commonRepository.getNextVal("NUT0002_SEQ");
			save = insertNut0002(item, CommonUtils.parseDouble(pkocs), hospCode);
		}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
			save = deleteNut0002(item, hospCode);
		}
		return save;
	}
	
	public boolean insertNut0001(NUT0001U00GrdNUT0001ItemInfo item, String hospCode){
		Nut0001 nut0001 = new Nut0001();
		nut0001.setSysDate(new Date());
		nut0001.setUserId(item.getUserId());
		nut0001.setUpdDate(new Date());
		nut0001.setHospCode(hospCode);
		nut0001.setPknut0001(CommonUtils.parseDouble(item.getPknut0001()));
		nut0001.setDataKubun(item.getDataKubun());
		nut0001.setFkOcs(CommonUtils.parseDouble(item.getFkOcs()));
		nut0001.setIoKubun(item.getIoKubun());
		nut0001.setHangmogCode(item.getHangmogCode());
		nut0001.setHangmogName(item.getHangmogName());
		nut0001.setIraiDate(DateUtil.toDate(item.getIraiDate(), DateUtil.PATTERN_YYMMDD));
		nut0001.setKanjaNo(item.getKanjaNo());
		nut0001.setSinryouka(item.getSinryouka());
		nut0001.setSindanisi(item.getSindanisi());
		nut0001.setBmi(CommonUtils.parseDouble(item.getBmi()));
		nut0001.setSijijikou(item.getSijijikou());
		nut0001.setTargetweight(CommonUtils.parseDouble(item.getTargetweight()));
		nut0001.setSportYn(item.getSportYn());
		nut0001.setDrinkYn(item.getDrinkYn());
		nut0001.setEnergy(CommonUtils.parseDouble(item.getEnergy()));
		nut0001.setProtein(CommonUtils.parseDouble(item.getProtein()));
		nut0001.setFat(CommonUtils.parseDouble(item.getFat()));
		nut0001.setPs(CommonUtils.parseDouble(item.getPs()));
		nut0001.setSugar(CommonUtils.parseDouble(item.getSugar()));
		nut0001.setSalt(CommonUtils.parseDouble(item.getSalt()));
		nut0001.setWater(CommonUtils.parseDouble(item.getWater()));
		nut0001.setBp(item.getBp());
		nut0001.setFbs(CommonUtils.parseDouble(item.getFbs()));
		nut0001.setA1c(CommonUtils.parseDouble(item.getA1C()));
		nut0001.setTch(CommonUtils.parseDouble(item.getTch()));
		nut0001.setTg(CommonUtils.parseDouble(item.getTg()));
		nut0001.setHdl(CommonUtils.parseDouble(item.getHdl()));
		nut0001.setLdl(CommonUtils.parseDouble(item.getLdl()));
		nut0001.setHb(CommonUtils.parseDouble(item.getHb()));
		nut0001.setAlb(CommonUtils.parseDouble(item.getAlb()));
		nut0001.setBun(CommonUtils.parseDouble(item.getBun()));
		nut0001.setCre(CommonUtils.parseDouble(item.getCre()));
		nut0001.setAstGot(CommonUtils.parseDouble(item.getAstGot()));
		nut0001.setAltGpt(CommonUtils.parseDouble(item.getAltGpt()));
		nut0001.setGammagt(CommonUtils.parseDouble(item.getGammagt()));
		nut0001.setHeight(CommonUtils.parseDouble(item.getHeight()));
		nut0001.setWeight(CommonUtils.parseDouble(item.getWeight()));
		nut0001.setSyokaiGubun(item.getSyokaiGubun());
		nut0001Repository.save(nut0001);
		return true;
	}
	public boolean updateNut0001(NUT0001U00GrdNUT0001ItemInfo item, String hospCode){
		if(nut0001Repository.updateNut0001U00SaveLayout( 
				DateUtil.toDate(item.getUpdDate(), DateUtil.PATTERN_YYMMDD),
				DateUtil.toDate(item.getIraiDate(), DateUtil.PATTERN_YYMMDD),
				CommonUtils.parseDouble(item.getBmi()),
				 item.getSijijikou(),
				 CommonUtils.parseDouble(item.getTargetweight()),
				 item.getSportYn(),
				 item.getDrinkYn(),
				 CommonUtils.parseDouble(item.getEnergy()),
				 CommonUtils.parseDouble(item.getProtein()),
				 CommonUtils.parseDouble(item.getFat()),
				 CommonUtils.parseDouble(item.getPs()),
				 CommonUtils.parseDouble(item.getSugar()),
				 CommonUtils.parseDouble(item.getSalt()),
				 CommonUtils.parseDouble(item.getWater()),
				 item.getBp(),
				 CommonUtils.parseDouble(item.getFbs()),
				 CommonUtils.parseDouble(item.getA1C()),
				 CommonUtils.parseDouble(item.getTch()),
				 CommonUtils.parseDouble(item.getTg()),
				 CommonUtils.parseDouble(item.getHdl()),
				 CommonUtils.parseDouble(item.getLdl()),
				 CommonUtils.parseDouble(item.getHb()),
				 CommonUtils.parseDouble(item.getAlb()),
				 CommonUtils.parseDouble(item.getBun()),
				 CommonUtils.parseDouble(item.getCre()),
				 CommonUtils.parseDouble(item.getAstGot()),
				 CommonUtils.parseDouble(item.getAltGpt()),
				 CommonUtils.parseDouble(item.getGammagt()),
				 item.getNutritionist(),
				 item.getNutritionistName(),
				 item.getNutritionObject(),
				 DateUtil.toDate(item.getActingDate(), DateUtil.PATTERN_YYMMDD),
				 item.getRemark(),
				 CommonUtils.parseDouble(item.getHeight()),
				 CommonUtils.parseDouble(item.getWeight()),
				 item.getSyokaiGubun(),
				 hospCode,
				 CommonUtils.parseDouble(item.getPknut0001()))>0){
			return true;
		}else{
			return false;
		}
	}
	
	public boolean deleteNut0001(NUT0001U00GrdNUT0001ItemInfo item){
		if(nut0001Repository.deleteNut0001U00SaveLayout(CommonUtils.parseDouble(item.getPknut0001())) > 0){
			return true;
		}else{
			return false;
		}
	}
	
	public boolean insertNut0002(NUT0001U00GrdNUT0002ItemInfo item, Double pkocs, String hospCode){
		Nut0002 nut0002 = new Nut0002();
		nut0002.setSysDate(new Date());
		nut0002.setUserId(item.getUserId());
		nut0002.setUpdDate(new Date());
		nut0002.setHospCode(hospCode);
		nut0002.setPknut0002(pkocs);
		nut0002.setDataKubun(item.getDataKubun());
		nut0002.setFknut0001(CommonUtils.parseDouble(item.getFknut0001()));
		nut0002.setFkoutsang(CommonUtils.parseDouble(item.getFkoutsang()));
		nut0002.setIoKubun(item.getIoKubun());
		nut0002Repository.save(nut0002);
		return true;
	}
	
	public boolean deleteNut0002(NUT0001U00GrdNUT0002ItemInfo item, String hospCode){
		if(nut0002Repository.deleteNut0001U00Nut0002SaveLayout(hospCode, CommonUtils.parseDouble(item.getPknut0002())) > 0){
			return true;
		}else{
			return false;
		}
	}
	
}