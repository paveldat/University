import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.function.Function;
import java.util.stream.Collectors;

import javax.swing.text.Utilities;


public class main {

	
	private static Map<String, Long> newMap = new HashMap<>();
	
	public static void main(String[] args) throws FileNotFoundException, IOException 
	{
		
		final String path = "D:\\filename.txt";
        try (BufferedReader reader = new BufferedReader(new FileReader(path))) {
            reader
                    .lines()
                    .flatMap(s -> Arrays.stream(s.split(" ")))
                    .forEach(s -> {
                    	newMap.compute(s, (key, value) -> (value != null) ? value + 1L : 1L);
                    });
        }

        Map<String, Long> result = newMap
                .entrySet()
                .stream()
                .sorted(Comparator.comparingLong(Map.Entry::getValue))
                .limit(10)
                .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));

        System.out.println(result);
		
	}	
       
	}