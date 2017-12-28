package nta.mss.misc.unit;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.powermock.core.classloader.annotations.PowerMockIgnore;
import org.powermock.core.classloader.annotations.PrepareForTest;
import org.powermock.modules.junit4.PowerMockRunner;

import nta.mss.repository.MovieTalkRepository;
import nta.mss.service.impl.MovieTalkService;
import static org.mockito.Mockito.*;
/**
 * 
 * @author TungLT
 *
 */

@RunWith(PowerMockRunner.class)
@PrepareForTest({MovieTalkService.class})
@PowerMockIgnore({ "org.w3c.*", "javax.xml.*", "org.apache.xerces.*", "javax.xml.parsers.*", "org.xml.sax.*" })
public class MovieTalkServiceTest {
	@Mock 
	MovieTalkRepository movietalkRepository;
	
	@InjectMocks
	MovieTalkService movieTalkService = new MovieTalkService();
	
	@Before
	public void setUp()
	{
		MockitoAnnotations.initMocks(this);
	}
	
	@Test
	public void testGetTotalRecordMovieTalkHistoryByHospIdAndPatientIdWithHasMovieTalk()
	{
		when(movietalkRepository.getTotalRecordMovieTalkHistoryByHospIdAndPatientId(115,"000000038,000000012,000000071,000000083,000000085")).thenReturn(1);
		movieTalkService.getTotalRecordMovieTalkHistoryByHospIdAndPatientId(115, "000000038,000000012,000000071,000000083,000000085");
		verify(movietalkRepository,times(1)).getTotalRecordMovieTalkHistoryByHospIdAndPatientId(115, "000000038,000000012,000000071,000000083,000000085");
	}
	
	@Test
	public void testGetTotalRecordMovieTalkHistoryByHospIdAndPatientIdWithHasNotMovieTalk()
	{
		when(movietalkRepository.getTotalRecordMovieTalkHistoryByHospIdAndPatientId(11345,"000000038,000000012,000000071,000000083,000000085")).thenReturn(0);
		movieTalkService.getTotalRecordMovieTalkHistoryByHospIdAndPatientId(11345, "000000038,000000012,000000071,000000083,000000085");
		verify(movietalkRepository,times(1)).getTotalRecordMovieTalkHistoryByHospIdAndPatientId(11345, "000000038,000000012,000000071,000000083,000000085");
	}
	@Test
	public void testGetListMovieTalkHistoryWithHasData()
	{

		movieTalkService.getListMovieTalkHistory(115, "000000038,000000012,000000071,000000083,000000085", 0, 10,
				"0", "asc");
		verify(movietalkRepository,times(1)).getListMovieTalkHistory(115, "000000038,000000012,000000071,000000083,000000085", 0, 10,
				"0", "asc");
	}
	
	@Test
	public void testGetListMovieTalkHistoryWithHasNotData()
	{

		movieTalkService.getListMovieTalkHistory(11512121, "000000038,000000012,000000071,000000083,000000085", 0, 10,
				"0", "asc");
		verify(movietalkRepository,times(1)).getListMovieTalkHistory(11512121, "000000038,000000012,000000071,000000083,000000085", 0, 10,
				"0", "asc");
	}
	
}
